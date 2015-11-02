using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawnMowers.Model;

namespace LawnMowers
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                FinishProgram("Usage: LawnMowers.exe \"AbsoluteFilePath\"");
            }

            var inputFilePath = args[0];


            if (!File.Exists(inputFilePath))
            {
                FinishProgram("The file path '" + inputFilePath + "' does not exists.");
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
                    var fieldWidth = 0u;
                    var fieldHeight = 0u;
                
                    if (fieldSize.Length < 2 || !uint.TryParse(fieldSize[0], out fieldWidth) ||
                         !uint.TryParse(fieldSize[1], out fieldHeight))
                    {
                        FinishProgram("The height/width of the Lawn is invalid. Expected 2 numbers separated by whitespace, for example: 5 5");
                    }

                    var lawnMowerIndex = 1;
                    while (!reader.EndOfStream)
                    {
                        var mowerLine = reader.ReadLine();

                        if (mowerLine == null)
                        {
                            FinishProgram("The position of the lawn mower #" + lawnMowerIndex + " is not in the file");
                            return;
                        }

                        var position = mowerLine.Split(' ');

                        var x = 0u;
                        var y = 0u;
                        var heading = LawnMower.Direction.N;

                        if (position.Length < 3 || !uint.TryParse(position[0], out x) ||
                            !uint.TryParse(position[1], out y) || !Enum.TryParse(position[2], out heading))
                        {
                            FinishProgram("The position of the lawn mower #" + lawnMowerIndex +
                                          " is invalid. Expected 2 numbers and a direction (N,S,E,W) separated by whitespace, for example: 1 2 N");
                        }

                        var lawnMower = new LawnMower(x, y, heading, fieldWidth, fieldHeight);
                        
                        var commandsLine = reader.ReadLine();

                        if (commandsLine == null)
                        {
                            FinishProgram("No commands provided for lawn mower #" + lawnMowerIndex +
                                         ". Expected a string with a combination of commands (L,R,M), for example: LMLMLMLMM");
                            return;
                        }
                     
                        var success = lawnMower.ExecuteCommands(commandsLine);

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

            Console.WriteLine("");
            Console.WriteLine("Output file with LawnMowers final positions was created successfully '" + outputFilePath + "'");
        }

        private static void FinishProgram(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

}
