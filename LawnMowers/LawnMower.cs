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


        public int X { get; private set; }
        public int Y { get; private set; }
     
        public Direction Heading { get; private set; }

        public LawnMower(int x, int y,  Direction heading)
        {
            Heading = heading;
            this.X = x;
            this.Y = y;
        }

        public void Move(Command command)
        {
            throw new NotImplementedException();
        }


        public void ChangeDirection(Command command)
        {
            throw new NotImplementedException();
        }
       

    }
}
