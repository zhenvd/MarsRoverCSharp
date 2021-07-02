using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newRover = new Rover(98382);
            Assert.AreEqual(newRover.Position, 98382);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(98382);
            Assert.AreEqual(newRover.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(98382);
            Assert.AreEqual(newRover.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };
            Message newMessage = new Message("Mode Change", commands);
            Rover newRover = new Rover(98382);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual("LOW_POWER", newRover.Mode); //expected, actual
        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            //Rover newRover = new Rover(98382);
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 100) };
            Message newMessage = new Message("Mode Change", commands);
            Rover newRover = new Rover(9001);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(9001, newRover.Position); //expected 9001, actual 9001. would not be able to
            //move to 100 because of LOW_POWER
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] commands = { new Command("MOVE", 100) };
            Message newMessage = new Message("Move", commands);
            Rover newRover = new Rover(98382);
            newRover.ReceiveMessage(newMessage);
            Assert.AreEqual(100, newRover.Position); //expected 100, actual 100
        }

        [TestMethod]
        public void RoverReturnsAMessageForAnUnknownCommand()
        {
            try
            {
                Command[] commands = { new Command("JUMP", 5) };
                Message newMessage = new Message("Jump", commands);
                Rover newRover = new Rover(19);
                newRover.ReceiveMessage(newMessage);
            }
            catch (ArgumentException x)
            {
                Assert.AreEqual("Invalid command.", x.Message); //expected 100, actual 100
            }
        }

    }


}
