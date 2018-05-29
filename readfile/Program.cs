using System;
using System.IO;

namespace MazeManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //input data from user
            string path  = PromptForValidFile("please enterthe  maze file path :");
            int maxPathsToFoundCnt = PromptForValidNumber("please enter the maximum paths to find :");
            
            //path = "c:\\maze / maze.txt"
            //maxPathsFound = 10000;

            //prepare maze generator and solver
            MazeGeneratorFromTxt mazeGenaratorFromTxt= new MazeGeneratorFromTxt(path);
            MazeSolver mazeSolver = new MazeSolver(maxPathsToFoundCnt);

            //instatiate mazecoordinator
            MazeCoordinator mazeCoordinator = new MazeCoordinator(mazeGenaratorFromTxt, mazeSolver);

            string errorMessage;

            //call in order to find available paths in maze
            mazeCoordinator.MazePaths(out errorMessage);
            
            //if errorMessage exists then show message
            if (errorMessage!=null && errorMessage.Length>0) {
                Console.WriteLine(errorMessage);
            }
            
            Console.ReadLine();

        }
        /// <summary>
        /// read a path from user input until file exists
        /// </summary>
        /// <param name="prompt">the promt to show for input data</param>
        /// <returns></returns>
        static int PromptForValidNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                int result;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Sorry, invalid number entered. Try again.");
            }
        }

        /// <summary>
        /// read a number from user input 
        /// </summary>
        /// <param name="prompt">the promt to show for input data</param>
        /// <returns></returns>
        static string PromptForValidFile(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string path = Console.ReadLine();
                if (File.Exists(path))
                {
                    return path;
                }
                Console.WriteLine("Sorry, file does not exist. Try again.");
            }
        }

    }
}
