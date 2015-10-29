using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowers
{
    public class LawnMower
    {
        public enum Direction { N, E, S, W }
        public enum Command { L, R, M }

        private LawnMowerPosition _lawnMowerPosition;
        

        private int _lawnWidth;
        private int _lawnHeight;

        public LawnMower(int x, int y, Direction heading, int rightBoundary, int topBoundary)
        {
            _lawnMowerPosition = new LawnMowerPosition(heading, x, y);
            _lawnWidth = rightBoundary;
            _lawnHeight = topBoundary;
        }

        public LawnMowerPosition GetPosition()
        {
            return _lawnMowerPosition;
        }

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

        private void Move()
        {
            switch (_lawnMowerPosition.Heading)
            {
                case Direction.N:
                    if (_lawnMowerPosition.Y + 1 <= _lawnHeight)
                        _lawnMowerPosition.Y += 1;
                    break;
                case Direction.W:
                    if (_lawnMowerPosition.X - 1 >= 0)
                        _lawnMowerPosition.X -= 1;
                    break;
                case Direction.S:
                    if (_lawnMowerPosition.Y - 1 >= 0)
                        _lawnMowerPosition.Y -= 1;
                    break;
                case Direction.E:
                    if (_lawnMowerPosition.X + 1 <= _lawnWidth)
                        _lawnMowerPosition.X += 1;
                    break;
            }
        }

        private void ChangeDirection(Command command)
        {
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
