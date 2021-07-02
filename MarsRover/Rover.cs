using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public void ReceiveMessage(Message message)
        {
            //Rover newRover = new Rover(Position);
            //Console.WriteLine(newRover.ToString());
            //newRover.ReceiveMessage(message);
            for(int i = 0; i < message.Commands.Length; i++)
            {
                if(message.Commands[i].CommandType.Equals("MODE_CHANGE"))
                {
                    Mode = message.Commands[i].NewMode;
                }
                else if(message.Commands[i].CommandType.Equals("MOVE"))
                {
                    if(Mode != "LOW_POWER")
                    {
                        Position = message.Commands[i].NewPosition;
                    }
                }
                else if(message.Commands[i].CommandType != "MOVE" || message.Commands[i].CommandType != "MODE_CHANGE")
                {
                    throw new ArgumentException("Invalid command.");
                }
            }
            //Console.WriteLine(newRover.ToString());
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
