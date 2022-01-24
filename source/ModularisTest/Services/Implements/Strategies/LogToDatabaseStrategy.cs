using ModularisTest.Exceptions;
using ModularisTest.Models;
using ModularisTest.Models.Enumerables;
using ModularisTest.Services.Implements.DAL;
using ModularisTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.Strategies
{
    public class LogToDatabaseStrategy : LogBase, ILogger
    {
        public LogToDatabaseStrategy(Message message)
        {
            _initialized = true;
            _message = message;
        }

        public async Task LogMessage()
        {
            if (!_initialized) throw new JobLoggerNotInitializedException();

            await MessagesService.InstanceSingleton.Add(_message);
        }
    }
}
