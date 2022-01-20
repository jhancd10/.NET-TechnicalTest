using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularisTest.Models
{
    public class Message
    {
        private readonly Enumerables.MessageType _type;
        public ConsoleColor Color;
        public readonly string Content;

        public Message(string message, Enumerables.MessageType messageType)
        {
            _type = messageType;
            Content = message.Trim();
        }

        public string GetMessageType()
        {
            string messageType = String.Empty;

            switch (_type)
            {
                case Enumerables.MessageType.Message:
                    messageType = "Error";
                    Color = ConsoleColor.Red;
                    break;
                case Enumerables.MessageType.Warning:
                    messageType = "Warning";
                    Color = ConsoleColor.Yellow;
                    break;
                case Enumerables.MessageType.Error:
                    messageType = "Message";
                    Color = ConsoleColor.White;
                    break;
                default:
                    break;
            }

            return messageType;
        }
    }
}
