using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeManager
{
    class MazeCoordinator : ICanCoordinateMaze
    {
        private ICanBuildMaze _mazebuilder;
        private ICanSolveMaze _mazeSolver;
        List<List<Node>> _pathstoGoal;
        /// <summary>
        /// that basic class that manages that executes maze finding paths procedure, error handling, printing and future logging   
        /// </summary>
        /// <param name="mazebuilder">a builder to generate the from a general type of input</param>
        /// <param name="mazeSolver">a mage solver tha has maze inputs in order to find the paths</param>
        public MazeCoordinator(ICanBuildMaze mazebuilder, ICanSolveMaze mazeSolver)
        {
            _mazebuilder = mazebuilder;
            _mazeSolver = mazeSolver;
        }
        /// <summary>
        /// the function that binds the maze generator with , maze solver
        /// </summary>
        /// <param name="errorMessage">when error occurs then message </param>
        public void MazePaths(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Maze maze = _mazebuilder.GenerateMaze();
                _pathstoGoal = _mazeSolver.FindPaths(maze);
                if (_pathstoGoal.Count > 0)
                {
                    Console.WriteLine();
                    showPaths();
                }
                else
                {
                    Console.WriteLine("The maze goal is unreachable.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }
        public void showPaths()
        {
            StringBuilder str = new StringBuilder();
            foreach (var path in _pathstoGoal)
            {
                foreach (var nodePrint in path)
                {
                    if (nodePrint.Type == NodeType.Empty)
                    {
                        str.AppendFormat("({0}:{1}),", nodePrint.Coordinates.Y, nodePrint.Coordinates.X);
                    }
                    else if (nodePrint.Type == NodeType.Start)
                    {
                        str.AppendFormat("({0}:{1} (S)),", nodePrint.Coordinates.Y, nodePrint.Coordinates.X);
                    }
                    else if (nodePrint.Type == NodeType.Goal)
                    {
                        str.AppendFormat("({0}:{1} (G))", nodePrint.Coordinates.Y, nodePrint.Coordinates.X);
                    }

                }
                str.AppendLine();
            }
            Console.WriteLine(str.ToString());
        }
    }
}
