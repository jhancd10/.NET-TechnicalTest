using ModularisTest.Models;
using ModularisTest.Services.Implements.Strategies;
using ModularisTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Services
{
    public class StrategiesContextController
    {
        //Control for strategies to use
        private ILogger _loggerMessage;

        //Message to log
        private Message _message;

        //LogTypes to log message
        private HashSet<Models.Enumerables.LogType> _logTypes;

        public StrategiesContextController(Message message, HashSet<Models.Enumerables.LogType> logTypes)
        {
            _message = message;
            _logTypes = logTypes;
        }

        public async Task LogMessage()
        {
            if (_message != null)
            {
                if (!String.IsNullOrEmpty(_message.Content) && _logTypes.Count != 0)
                {
                    //List of task to complete
                    List<Task> taskList = new List<Task>();

                    //Concurrent foreach to complete strategies at time
                    Parallel.ForEach(_logTypes, new ParallelOptions() { MaxDegreeOfParallelism = 3 }, logType =>
                    {
                        //Choose a strategy depending logType
                        switch (logType)
                        {
                            case Models.Enumerables.LogType.Console:
                                _loggerMessage = new LogToConsoleStrategy(_message);
                                break;

                            case Models.Enumerables.LogType.File:
                                _loggerMessage = new LogToFileStrategy(_message);
                                break;

                            case Models.Enumerables.LogType.Database:
                                _loggerMessage = new LogToDatabaseStrategy(_message);
                                break;
                        }
                        //Execute strategy
                        taskList.Add(_loggerMessage.LogMessage());
                    });

                    //Waiting for task will be completed
                    await Task.WhenAll(taskList);
                }
            }
        }
    }
}
