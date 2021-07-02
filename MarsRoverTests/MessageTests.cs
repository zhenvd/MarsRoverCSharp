using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Command type required.", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("MOVE");
            Assert.AreEqual(newMessage.Name, "MOVE");
        }

        [TestMethod]
        public void ConstructorSetsCommandField()
        {
            Message newCommandField = new Message("MOVE", commands);
            Assert.AreEqual(newCommandField.Commands, commands);
        }
    }
}
