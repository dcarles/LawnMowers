namespace LawnMowers
{
    public class LawnMowerPosition
    {
        public LawnMowerPosition(LawnMower.Direction heading, int x, int y)
        {
            Heading = heading;
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public LawnMower.Direction Heading { get; set; }

        public override string ToString()
        {
            return X + " " + Y + " " + " " + Heading;
        }
    }
}