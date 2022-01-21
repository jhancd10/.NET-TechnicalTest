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
            //Get properties from message depending its type
            string messageType = String.Empty;

            switch (_type)
            {
                case Enumerables.MessageType.Message:
                    messageType = Enum.GetName(typeof(Enumerables.MessageType), Enumerables.MessageType.Message);
                    Color = ConsoleColor.Red;
                    break;
                case Enumerables.MessageType.Warning:
                    messageType = Enum.GetName(typeof(Enumerables.MessageType), Enumerables.MessageType.Warning);
                    Color = ConsoleColor.Yellow;
                    break;
                case Enumerables.MessageType.Error:
                    messageType = Enum.GetName(typeof(Enumerables.MessageType), Enumerables.MessageType.Error);
                    Color = ConsoleColor.White;
                    break;
            }

            return messageType;
        }
    }
}
