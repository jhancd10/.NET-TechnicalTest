using ModularisTest.Exceptions;
using ModularisTest.Models;
using ModularisTest.Models.Enumerables;
using ModularisTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.Strategies
{
    public class LogToFileStrategy : LogBase, ILogger
    {
        private PathFile _instanceSingletonPathFile;

        public LogToFileStrategy(Message message)
        {
            _initialized = true;
            _message = message;
            _instanceSingletonPathFile = PathFile.InstanceSingleton;
        }

        public async Task LogMessage()
        {
            if (!_initialized) throw new JobLoggerNotInitializedException();

            //Get the text with new message to log into file
            string text = _instanceSingletonPathFile.GetFileText(_message);
            await _instanceSingletonPathFile.SaveFileText(text);
        }
    }
}
