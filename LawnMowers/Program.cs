using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowers
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filename = "sample";
            string filename = "sample";
            //string filename = "B-large";
            using (StreamReader reader = new StreamReader("..\\..\\" + filename + ".in"))
            {
                using (StreamWriter writer = new StreamWriter("..\\..\\" + filename + ".out"))
                {
                    int fieldSize = Int32.Parse(reader.ReadLine());

                    LawnMower mower = new LawnMower();
                       
                    }
                }
            }
        }
    
}
