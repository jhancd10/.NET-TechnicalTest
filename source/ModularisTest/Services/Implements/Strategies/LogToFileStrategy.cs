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
        private readonly string _logFullFilePath;

        public LogToFileStrategy(Message message, string logFullFilePath)
        {
            _initialized = true;
            _message = message;
            _logFullFilePath = logFullFilePath;
        }

        public void LogMessage()
        {
            string fileText = String.Empty;

            if (File.Exists(_logFullFilePath))
            {
                fileText = File.ReadAllText(_logFullFilePath);
            }

            fileText += DateTime.Now.ToShortDateString() + " " + _message.GetMessageType() + " " + _message.Content + Environment.NewLine;

            if (!Directory.Exists(_logFullFilePath)) Directory.CreateDirectory(_logFullFilePath);

            File.WriteAllText(_logFullFilePath, fileText);
        }
    }
}
