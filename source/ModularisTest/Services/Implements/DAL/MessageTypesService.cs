using ModularisTest.Models.DAL;
using ModularisTest.Services.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.DAL
{
    public class MessageTypesService : IActions_LowerClass<MESSAGE_TYPES>
    {
        //Singleton

        private static MessageTypesService _instanceSingleton = null;

        public static MessageTypesService InstanceSingleton
        {
            //Creation of new Instance and connection to DB
            get
            {
                if (_instanceSingleton == null)
                {
                    _instanceSingleton = new MessageTypesService();
                }
                return _instanceSingleton;
            }
        }

        public bool Add(MESSAGE_TYPES type, LocalEntities contexto = null)
        {
            //If is null, recreate context 
            bool recreate = (contexto == null);
            if (recreate) { contexto = UtilsService.InstanceSingleton.ContextDBCreate(); }

            //Add new message type to DB

            bool result = true;
            try
            {
                MESSAGE_TYPES typeDB = contexto.MESSAGE_TYPES.AsNoTracking()
                                       .FirstOrDefault(x => x.ID == type.ID);
                if (typeDB == null)
                {
                    contexto.MESSAGE_TYPES.Add(type);
                    contexto.SaveChanges();
                }
            }

            catch (Exception ex) { result = false; }

            if (recreate) { contexto.Dispose(); }

            return result;
        }
    }
}
