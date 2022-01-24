using ModularisTest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Interfaces.DAL
{
    //using Interface Segregation Principle (ISP)

    interface IActions_HigherClass<T>
    {
        Task<bool> Add(T entity);
    }

    interface IActions_LowerClass<T>
    {
        bool Add(T entity, LocalEntities contexto = null);
    }

    interface IBasicActions<T>
    {
        List<T> GetList();
    }
}
