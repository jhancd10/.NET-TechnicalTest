using ModularisTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModularisTest.Models;
using System.Collections.Generic;
using ModularisTest.Services;
using System.Threading.Tasks;

namespace ModularisTestUnitTests
{
    [TestClass]
    public class JobLoggerTest
    {
        private const string TestMessage = "Test-#1 to log Message in Console-File-DB";
        private const string WarningMessage = "Test-#2 to log Warning in Console-File-DB";
        private const string ErrorMessage = "Test-#3 to log Error in Console-File-DB";

        [TestMethod]
        public void JobLoggerBasicTestImproved()
        {
            //Message Creation
            Message message = new Message(TestMessage, ModularisTest.Models.Enumerables.MessageType.Message);

            //LogTypes destination to log Message
            HashSet<ModularisTest.Models.Enumerables.LogType> logTypes = new HashSet<ModularisTest.Models.Enumerables.LogType>(
            new ModularisTest.Models.Enumerables.LogType[]
            {
                ModularisTest.Models.Enumerables.LogType.Console,
                ModularisTest.Models.Enumerables.LogType.File,
                ModularisTest.Models.Enumerables.LogType.Database
            });

            //Begin the process 
            StrategiesContextController jobLogger = new StrategiesContextController(message, logTypes);

            //Log message to different destinations
            Task.Run(() =>
            {
                return jobLogger.LogMessage();

            }).GetAwaiter().GetResult(); //Waiting for all tasks will be finished
        }
    }
}