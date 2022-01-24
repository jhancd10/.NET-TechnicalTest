using ModularisTest.Models;
using ModularisTest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.DAL
{
    public class UtilsService
    {
        //Singleton

        private static UtilsService _instanceSingleton = null;

        public static UtilsService InstanceSingleton
        {
            //Creation of new Instance and connection to DB
            get
            {
                if (_instanceSingleton == null)
                {
                    _instanceSingleton = new UtilsService();
                }
                return _instanceSingleton;
            }
        }

        public LocalEntities ContextDBCreate()
        {
            var contexto = new LocalEntities();
            contexto.Configuration.ProxyCreationEnabled = false;
            contexto.Configuration.LazyLoadingEnabled = false;
            return contexto;
        }
    }
}
