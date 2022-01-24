using ModularisTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Interfaces
{
    interface ILogger
    {
        Task LogMessage();
    }
}
