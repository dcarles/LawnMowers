namespace LawnMowers.Model
{
    public class LawnMowerPosition
    {
        public LawnMowerPosition(LawnMower.Direction heading, uint x, uint y)
        {
            Heading = heading;
            X = x;
            Y = y;
        }

        public uint X { get; set; }
        public uint Y { get; set; }
        public LawnMower.Direction Heading { get; set; }

        public override string ToString()
        {
            return X + " " + Y + " " + " " + Heading;
        }
    }
}