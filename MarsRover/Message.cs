using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; } //name of message
        public Command[] Commands { get; set; }

        public Message()
        {
        }
        public Message(string message)
        {
            Name = message;
            if (String.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException(Name, "Command type required.");
            }
        }
        public Message(string name, Command[] commands)
        {
            Name = name;
            Commands = commands;
        }
    }
}
