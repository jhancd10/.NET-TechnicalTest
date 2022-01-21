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
        private readonly string _logFullFilePath;

        public LogToFileStrategy(Message message, string logFullFilePath)
        {
            _initialized = true;
            _message = message;
            _logFullFilePath = logFullFilePath;
        }

        private string GetFileText()
        {
            string fileText = String.Empty;

            //Verify if file exist and get the content
            try
            {
                fileText = File.ReadAllText(_logFullFilePath);
            }

            //Create directory, so the file will be empty
            catch (Exception)
            {
                Directory.CreateDirectory(_logFullFilePath);
            }

            //New text to add
            fileText += DateTime.Now.ToShortDateString() + " " + _message.GetMessageType() + " " + _message.Content + Environment.NewLine;
            return fileText;
        }

        public void LogMessage()
        {
            if (!_initialized) throw new JobLoggerNotInitializedException();

            //Get the text with new message to log into file
            string text = GetFileText();
            File.WriteAllText(_logFullFilePath, text);
        }
    }
}
