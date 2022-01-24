using ModularisTest.Models.DAL;
using ModularisTest.Services.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.DAL
{
    public class MessageColorsServices : IActions_LowerClass<MESSAGE_COLORS>
    {
        //Singleton
        
        private static MessageColorsServices _instanceSingleton = null;

        public static MessageColorsServices InstanceSingleton
        {
            //Creation of new Instance and connection to DB
            get
            {
                if (_instanceSingleton == null)
                {
                    _instanceSingleton = new MessageColorsServices();
                }
                return _instanceSingleton;
            }
        }

        public bool Add(MESSAGE_COLORS color, LocalEntities contexto = null)
        {
            //If is null, recreate context 
            bool recreate = (contexto == null);
            if (recreate) { contexto = UtilsService.InstanceSingleton.ContextDBCreate(); }

            //Add new message color to DB

            bool result = true;
            try
            {
                MESSAGE_COLORS colorDB = contexto.MESSAGE_COLORS.AsNoTracking()
                                         .FirstOrDefault(x => x.ID == color.ID);
                if (colorDB == null)
                {
                    contexto.MESSAGE_COLORS.Add(color);
                    contexto.SaveChanges();
                }
            }

            catch (Exception ex) { result = false; }

            if (recreate) { contexto.Dispose(); }

            return result;
        }
    }
}
