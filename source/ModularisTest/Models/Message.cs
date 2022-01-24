using ModularisTest.Models.DAL;
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
        public string Content;

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
                    Color = ConsoleColor.White;
                    break;

                case Enumerables.MessageType.Warning:
                    messageType = Enum.GetName(typeof(Enumerables.MessageType), Enumerables.MessageType.Warning);
                    Color = ConsoleColor.Yellow;
                    break;

                case Enumerables.MessageType.Error:
                    messageType = Enum.GetName(typeof(Enumerables.MessageType), Enumerables.MessageType.Error);
                    Color = ConsoleColor.Red;
                    break;
            }

            return messageType;
        }

        public (MESSAGES, MESSAGE_TYPES, MESSAGE_COLORS) GetEntitiesDB()
        {
            GetMessageType();

            //Get entities database from Message

            //MESSAGE_COLORS Entity
            MESSAGE_COLORS color = new MESSAGE_COLORS()
            {
                ID = (int) Color,
                COLOR = Enum.GetName(typeof(ConsoleColor), Color)
            };

            //MESSAGE_TYPES Entity
            MESSAGE_TYPES type = new MESSAGE_TYPES()
            {
                ID = (int) _type,
                TYPE = Enum.GetName(typeof(Enumerables.MessageType), _type),
                COLOR_ID = (int) Color
            };

            //MESSAGES Entity
            MESSAGES message = new MESSAGES()
            {
                CONTENT = Content,
                TYPE_ID = (int) _type,
                DATE = DateTime.Now
            };

            return (message, type, color);
        }
    }
}
