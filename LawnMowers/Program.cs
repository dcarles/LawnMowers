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
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid argument. Expected filename without extension");
                Environment.Exit(0);
            }

            var inputFilePath = args[0];


            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("The file path '" + inputFilePath + "' does not exists.");
                Environment.Exit(0);
            }

            MownTheLawn(inputFilePath);
        }

        private static void MownTheLawn(string inputFilePath)
        {
            var tempSplitPath = inputFilePath.Split('\\');
            var outputFilePath = inputFilePath.Replace(tempSplitPath[tempSplitPath.Length - 1], "output.txt");

            using (var reader = new StreamReader(inputFilePath))
            {
                using (var writer = new StreamWriter(outputFilePath))
                {
                    var fieldSize = reader.ReadLine().Split(' ');

                    if (fieldSize.Length == 0)
                    {
                        Console.WriteLine(
                            "Invalid first line in the input file. Expected 2 numbers separated by a whitespace, for example: 5 5");
                        Environment.Exit(0);
                    }

                    var fieldSizeWidth = int.Parse(fieldSize[0]);
                    var fieldSizeHeight = int.Parse(fieldSize[1]);

                    var lawnMowerIndex = 1;
                    while (!reader.EndOfStream)
                    {
                        var position = reader.ReadLine().Split(' ');

                        var x = 0;
                        var y = 0;
                        var heading = LawnMower.Direction.N;

                        if (position.Length < 3 || !int.TryParse(position[0], out x) ||
                            !int.TryParse(position[1], out y) || !Enum.TryParse(position[2], out heading))
                        {
                            Console.WriteLine("The position of the lawn mower #" + lawnMowerIndex +
                                              " is invalid. Expected 2 numbers and a direction (N,S,E,W) separated by whitespace, for example: 1 2 N");
                            Environment.Exit(0);
                        }

                        var lawnMower = new LawnMower(x, y, heading);


                        if (reader.EndOfStream)
                        {
                            Console.WriteLine("No commands provided for lawn mower #" + lawnMowerIndex +
                                              ". Expected a string with a combination of commands (L,R,M), for example: LMLMLMLMM");
                            Environment.Exit(0);
                        }

                        var commands = reader.ReadLine();
                        var success = lawnMower.ExecuteCommands(commands);

                        if (!success)
                        {
                            Console.WriteLine("The commands provided for lawn mower #" + lawnMowerIndex +
                                              "are invalid. Expected a string with a combination of commands (L,R,M) with no whitespaces, for example: LMLMLMLMM");
                            Environment.Exit(0);
                        }

                        writer.WriteLine(lawnMower.LawnMowerPosition.ToString());

                        lawnMowerIndex++;
                    }
                }
            }
        }
    }

}
