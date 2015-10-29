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

        public LawnMowerPosition LawnMowerPosition { get; private set; }
   
        public LawnMower(int x, int y, Direction heading)
        {
            LawnMowerPosition = new LawnMowerPosition(heading, x, y);
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
                    Move(command);
            }

            return true;
        }

        private void Move(Command command)
        {
            throw new NotImplementedException();
        }

        private void ChangeDirection(Command command)
        {
            switch (command)
            {
                case Command.L:
                    switch (LawnMowerPosition.Heading)
                    {
                        case Direction.N:
                            LawnMowerPosition.Heading = Direction.W;
                            break;
                        case Direction.W:
                            LawnMowerPosition.Heading = Direction.S;
                            break;
                        case Direction.S:
                            LawnMowerPosition.Heading = Direction.E;
                            break;
                        case Direction.E:
                            LawnMowerPosition.Heading = Direction.N;
                            break;
                    }
                    break;
                case Command.R:
                    switch (LawnMowerPosition.Heading)
                    {
                        case Direction.N:
                            LawnMowerPosition.Heading = Direction.E;
                            break;
                        case Direction.E:
                            LawnMowerPosition.Heading = Direction.S;
                            break;
                        case Direction.S:
                            LawnMowerPosition.Heading = Direction.W;
                            break;
                        case Direction.W:
                            LawnMowerPosition.Heading = Direction.N;
                            break;
                    }
                    break;
            }
        }

    }
}
