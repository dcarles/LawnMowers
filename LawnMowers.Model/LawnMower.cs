using System;

namespace LawnMowers.Model
{
    /// <summary>
    /// Robotic lawn mower to be deployed to trim the grass of a large lawn
    /// </summary>
    public class LawnMower
    {
        public enum Direction { N, E, S, W }
        public enum Command { L, R, M }

        private LawnMowerPosition _lawnMowerPosition;


        private uint _lawnWidth;
        private uint _lawnHeight;

        public LawnMower(uint x, uint y, Direction heading, uint rightBoundary, uint topBoundary)
        {
            if (x > rightBoundary)
            {
                throw new ArgumentException("Initial X Position of the LawnMower should be less than the Width of the Lawn.");
            }

            if (y > topBoundary)
            {
                throw new ArgumentException("Initial Y Position of the LawnMower should be less than the Height of the Lawn.");
            }


            _lawnMowerPosition = new LawnMowerPosition(heading, x, y);
            _lawnWidth = rightBoundary;
            _lawnHeight = topBoundary;
        }

        public LawnMowerPosition GetPosition()
        {
            return _lawnMowerPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public bool ExecuteCommands(string commands)
        {
            foreach (var c in commands)
            {
                Command command;
                if (!Enum.TryParse(c.ToString().ToUpper(), out command))
                    return false;

                if (command == Command.L || command == Command.R)
                    ChangeDirection(command);
                else
                    Move();
            }

            return true;
        }

        /// <summary>
        /// Move forward one grid point, and maintain the same heading
        /// Assume that the square directly North from (x, y) is (x, y+1)
        /// </summary>
        public void Move()
        {
            switch (_lawnMowerPosition.Heading)
            {
                case Direction.N:
                    if (_lawnMowerPosition.Y + 1 <= _lawnHeight)
                        _lawnMowerPosition.Y += 1;
                    break;
                case Direction.W:
                    if (_lawnMowerPosition.X > 0)
                        _lawnMowerPosition.X -= 1;
                    break;
                case Direction.S:
                    if (_lawnMowerPosition.Y > 0)
                        _lawnMowerPosition.Y -= 1;
                    break;
                case Direction.E:
                    if (_lawnMowerPosition.X + 1 <= _lawnWidth)
                        _lawnMowerPosition.X += 1;
                    break;
            }
        }

        /// <summary>
        /// It change the direction of the Lawn Mower.
        /// 'L' and 'R' makes the mower spin 90 degrees left or right respectively
        /// </summary>
        /// <param name="command">Should be L or R</param>
        public void ChangeDirection(Command command)
        {
            
            if (command != Command.L && command != Command.R)
            {
                throw new ArgumentException("The command provided is invalid expected L or R");
            }

            switch (command)
            {
                case Command.L:
                    switch (_lawnMowerPosition.Heading)
                    {
                        case Direction.N:
                            _lawnMowerPosition.Heading = Direction.W;
                            break;
                        case Direction.W:
                            _lawnMowerPosition.Heading = Direction.S;
                            break;
                        case Direction.S:
                            _lawnMowerPosition.Heading = Direction.E;
                            break;
                        case Direction.E:
                            _lawnMowerPosition.Heading = Direction.N;
                            break;
                    }
                    break;
                case Command.R:
                    switch (_lawnMowerPosition.Heading)
                    {
                        case Direction.N:
                            _lawnMowerPosition.Heading = Direction.E;
                            break;
                        case Direction.E:
                            _lawnMowerPosition.Heading = Direction.S;
                            break;
                        case Direction.S:
                            _lawnMowerPosition.Heading = Direction.W;
                            break;
                        case Direction.W:
                            _lawnMowerPosition.Heading = Direction.N;
                            break;
                    }
                    break;
            }
        }

    }
}
