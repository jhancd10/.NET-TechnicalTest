using ModularisTest.Models;
using ModularisTest.Models.DAL;
using ModularisTest.Services.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.DAL
{
    public class MessagesService : IActions_HigherClass<Message>, IBasicActions<MESSAGES>
    {
        //Singleton

        private static MessagesService _instanceSingleton = null;
        private LocalEntities _contexto = null;

        private MessagesService()
        {
            //Context DB Construction
            _contexto = UtilsService.InstanceSingleton.ContextDBCreate();
        }

        public static MessagesService InstanceSingleton
        {
            //Creation of new Instance and connection to DB
            get
            {
                if (_instanceSingleton == null)
                {
                    _instanceSingleton = new MessagesService();
                }
                return _instanceSingleton;
            }
        }

        public async Task<bool> Add(Message message)
        {
            //Add new message to DB

            bool result = false;

            using (_contexto)
            {
                using (DbContextTransaction transaction = _contexto.Database.BeginTransaction())
                {
                    try
                    {
                        //Get entities from Message
                        (MESSAGES, MESSAGE_TYPES, MESSAGE_COLORS) entities = message.GetEntitiesDB();

                        //Save message type in DB
                        if (MessageColorsServices.InstanceSingleton.Add(entities.Item3, _contexto))
                        {
                            //Save message color in DB
                            if (MessageTypesService.InstanceSingleton.Add(entities.Item2, _contexto))
                            {
                                //Save message in DB
                                _contexto.MESSAGES.Add(entities.Item1);
                                await _contexto.SaveChangesAsync();

                                transaction.Commit();
                                result = true;
                            }

                            else { transaction.Rollback(); }
                        }

                        else { transaction.Rollback(); }
                    }

                    catch (Exception ex) { transaction.Rollback(); }
                }
            }
            return result;
        }

        public List<MESSAGES> GetList()
        {
            //Get list from all messages in DB

            List<MESSAGES> messagesList = new List<MESSAGES>();
            try
            {
                messagesList = _contexto.MESSAGES.AsNoTracking().ToList();
            }

            catch (Exception) { }

            return messagesList;
        }
    }
}
