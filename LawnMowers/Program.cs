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
                    var readLine = reader.ReadLine();
                    if (readLine == null)
                    {
                        FinishProgram("Input file has no lines");
                        return;
                    }

                    var fieldSize = readLine.Split(' ');

                    if (fieldSize.Length == 0)
                    {
                        FinishProgram("Invalid first line in the input file. Expected 2 numbers separated by a whitespace, for example: 5 5");
                    }

                    var fieldWidth = int.Parse(fieldSize[0]);
                    var fieldHeight = int.Parse(fieldSize[1]);

                    var lawnMowerIndex = 1;
                    while (!reader.EndOfStream)
                    {
                        var position = readLine.Split(' ');

                        var x = 0;
                        var y = 0;
                        var heading = LawnMower.Direction.N;

                        if (position.Length < 3 || !int.TryParse(position[0], out x) ||
                            !int.TryParse(position[1], out y) || !Enum.TryParse(position[2], out heading))
                        {
                            FinishProgram("The position of the lawn mower #" + lawnMowerIndex +
                                          " is invalid. Expected 2 numbers and a direction (N,S,E,W) separated by whitespace, for example: 1 2 N");
                        }

                        var lawnMower = new LawnMower(x, y, heading, fieldWidth, fieldHeight);


                        if (reader.EndOfStream)
                        {
                            FinishProgram("No commands provided for lawn mower #" + lawnMowerIndex +
                                          ". Expected a string with a combination of commands (L,R,M), for example: LMLMLMLMM");
                        }

                        var commands = readLine;
                        var success = lawnMower.ExecuteCommands(commands);

                        if (!success)
                        {
                            FinishProgram("The commands provided for lawn mower #" + lawnMowerIndex +
                                          "are invalid. Expected a string with a combination of commands (L,R,M) with no whitespaces, for example: LMLMLMLMM");
                        }

                        writer.WriteLine(lawnMower.GetPosition().ToString());

                        lawnMowerIndex++;
                    }
                }
            }
        }

        private static void FinishProgram(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

}
