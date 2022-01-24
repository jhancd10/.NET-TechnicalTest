using ModularisTest.Exceptions;
using ModularisTest.Models;
using ModularisTest.Models.Enumerables;
using ModularisTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services.Implements.Strategies
{
    public class LogToConsoleStrategy : LogBase, ILogger
    {
        public LogToConsoleStrategy(Message message)
        {
            _initialized = true;
            _message = message;
        }

        public async Task LogMessage()
        {
            if (!_initialized) throw new JobLoggerNotInitializedException();

            //Log message to console
            string messageType =_message.GetMessageType();
            Console.ForegroundColor = _message.Color;
            await Task.Run(() => Console.WriteLine(DateTime.Now.ToShortDateString() + " " + messageType + " " + _message.Content));
        }
    }
}
