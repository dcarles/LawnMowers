using System;
using LawnMowers.Model;
using NUnit.Framework;

namespace LawnMowers.Tests
{
    [TestFixture]
    public class LawnMowerTests
    {
        #region Constructor Tests
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Lawn_Mower_Should_Not_Instantiate_And_Throw_Argument_Exception_If_X_Greater_Than_Lawn_Width()
        {
            var lawnMower = new LawnMower(7, 0, LawnMower.Direction.W, 5, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Lawn_Mower_Should_Not_Instantiate_And_Throw_Argument_Exception_If_Y_Greater_Than_Lawn_Height()
        {
            var lawnMower = new LawnMower(0, 7, LawnMower.Direction.W, 5, 5);
        }
        #endregion

        #region Move Tests

        [Test]
        public void Lawn_Mower_Should_Increase_Y_By_One_When_Moving_If_Is_Heading_North()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.N, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(0, lawnMower.GetPosition().X);
            Assert.AreEqual(1, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Increase_X_By_One_When_Moving_If_Is_Heading_East()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.E, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(1, lawnMower.GetPosition().X);
            Assert.AreEqual(0, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Decrease_X_By_One_When_Moving_If_Is_Heading_West()
        {
            var lawnMower = new LawnMower(1, 1, LawnMower.Direction.W, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(0, lawnMower.GetPosition().X);
            Assert.AreEqual(1, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Decrease_Y_By_One_When_Moving_If_Is_Heading_South()
        {
            var lawnMower = new LawnMower(1, 1, LawnMower.Direction.S, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(1, lawnMower.GetPosition().X);
            Assert.AreEqual(0, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Not_Move_When_Y_Is_Zero_If_Is_Heading_South()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.S, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(0, lawnMower.GetPosition().X);
            Assert.AreEqual(0, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Not_Move_When_X_Is_Zero_If_Is_Heading_West()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.W, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(0, lawnMower.GetPosition().X);
            Assert.AreEqual(0, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Not_Move_When_Y_Is_Equal_To_Lawn_Height_If_Is_Heading_North()
        {
            var lawnMower = new LawnMower(0, 5, LawnMower.Direction.N, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(0, lawnMower.GetPosition().X);
            Assert.AreEqual(5, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_Not_Move_When_X_Is_Equal_To_Lawn_With_If_Is_Heading_East()
        {
            var lawnMower = new LawnMower(5, 0, LawnMower.Direction.E, 5, 5);
            lawnMower.Move();

            Assert.AreEqual(5, lawnMower.GetPosition().X);
            Assert.AreEqual(0, lawnMower.GetPosition().Y);
        }

        #endregion

        #region ChangeDirection Tests

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Lawn_Mower_Should_Not_Change_Direction_And_Throw_Argument_Exception_If_Command_Is_Not_L_Or_R()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.W, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.M);
        }

        [Test]
        public void Lawn_Mower_Should_Head_West_When_Command_Is_Left_If_Is_Heading_North()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.N, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.L);
            Assert.AreEqual(LawnMower.Direction.W, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_South_When_Command_Is_Left_If_Is_Heading_West()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.W, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.L);
            Assert.AreEqual(LawnMower.Direction.S, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_East_When_Command_Is_Left_If_Is_Heading_South()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.S, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.L);
            Assert.AreEqual(LawnMower.Direction.E, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_North_When_Command_Is_Left_If_Is_Heading_East()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.E, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.L);
            Assert.AreEqual(LawnMower.Direction.N, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_East_When_Command_Is_Right_If_Is_Heading_North()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.N, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.R);
            Assert.AreEqual(LawnMower.Direction.E, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_South_When_Command_Is_Right_If_Is_Heading_East()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.E, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.R);
            Assert.AreEqual(LawnMower.Direction.S, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_West_When_Command_Is_Right_If_Is_Heading_South()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.S, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.R);
            Assert.AreEqual(LawnMower.Direction.W, lawnMower.GetPosition().Heading);
        }

        [Test]
        public void Lawn_Mower_Should_Head_North_When_Command_Is_Right_If_Is_Heading_West()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.W, 5, 5);
            lawnMower.ChangeDirection(LawnMower.Command.R);
            Assert.AreEqual(LawnMower.Direction.N, lawnMower.GetPosition().Heading);
        }

        #endregion

        #region ExecuteCommands Tests
        [Test]
        public void Lawn_Mower_Should_Not_Execute_Commands_If_One_Of_The_Commands_Is_Invalid()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.W, 5, 5);
            var success = lawnMower.ExecuteCommands("MLRZ");
            Assert.AreEqual(false, success);

        }

        [Test]
        public void Lawn_Mower_Should_Not_Execute_Commands_If_Command_String_Is_Invalid()
        {
            var lawnMower = new LawnMower(0, 0, LawnMower.Direction.W, 5, 5);
            var success = lawnMower.ExecuteCommands("test");
            Assert.AreEqual(false, success);
        }

        [Test]
        public void Lawn_Mower_Should_End_In_Position_One_Three_North_If_Initial_Position_Is_One_Two_North_And_Commands_Are_LMLMLMLMM()
        {
            var lawnMower = new LawnMower(1, 2, LawnMower.Direction.N, 5, 5);
            var success = lawnMower.ExecuteCommands("LMLMLMLMM");
            Assert.AreEqual(true, success);
            Assert.AreEqual(LawnMower.Direction.N, lawnMower.GetPosition().Heading);
            Assert.AreEqual(1, lawnMower.GetPosition().X);
            Assert.AreEqual(3, lawnMower.GetPosition().Y);
        }

        [Test]
        public void Lawn_Mower_Should_End_In_Position_Five_One_East_If_Initial_Position_Is_Three_Three_East_And_Commands_Are_MMRMMRMRRM()
        {
            var lawnMower = new LawnMower(3, 3, LawnMower.Direction.E, 5, 5);
            var success = lawnMower.ExecuteCommands("MMRMMRMRRM");
            Assert.AreEqual(true, success);
            Assert.AreEqual(LawnMower.Direction.E, lawnMower.GetPosition().Heading);
            Assert.AreEqual(5, lawnMower.GetPosition().X);
            Assert.AreEqual(1, lawnMower.GetPosition().Y);
        } 
        #endregion
        
    }
}
