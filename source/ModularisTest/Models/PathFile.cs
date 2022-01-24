using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Models
{
    public class PathFile
    {
        //Singleton

        private static PathFile _instanceSingleton = null;

        private string _logFolder = String.Empty;
        private string _logFileName = String.Empty;
        private string _logFullFilePath = String.Empty;

        public static PathFile InstanceSingleton
        {
            //Creation of new Instance
            get
            {
                if (_instanceSingleton == null)
                {
                    _instanceSingleton = new PathFile();
                    _instanceSingleton.GetPathFile();
                }
                return _instanceSingleton;
            }
        }

        private void GetPathFile()
        {
            if (String.IsNullOrEmpty(_logFullFilePath))
            {
                _logFolder = ConfigurationManager.AppSettings["LogFileDirectory"];
                
                if (string.IsNullOrEmpty(_logFolder))
                {
                    _logFolder = Environment.CurrentDirectory;
                }

                _logFileName = "LogFile" + DateTime.Now.ToShortDateString().Replace("/", ".") + ".txt";
                _logFullFilePath = Path.Combine(_logFolder.Replace(@"\\", @"\"), _logFileName);
            }
        }

        public string GetFileText(Message message)
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
                if (!Directory.Exists(_logFolder))
                {
                    Directory.CreateDirectory(_logFolder);
                }
            }

            //New text to add
            fileText += DateTime.Now.ToShortDateString() + " " + message.GetMessageType() + " " + message.Content + Environment.NewLine;
            return fileText;
        }

        public async Task SaveFileText(string text)
        {
            await Task.Run(() => File.WriteAllText(_logFullFilePath, text));
        }
    }
}
