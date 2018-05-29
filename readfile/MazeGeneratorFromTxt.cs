using Model;
using Public;
using System;
using System.Drawing;
using System.IO;

namespace MazeManager
    {/// <summary>
    /// Maze generator using txt files with spesific format X : wall, _ : empty, S: start, G: goal
    /// </summary>
    public class MazeGeneratorFromTxt: ICanBuildMaze
    {
        private string _mazeFilePath;
        private string[] _lines;
        private int _height;
        private int _width;
        private Node _startNode ;
        private Node _goalNode ;
        private Node[,] _nodes;

        public MazeGeneratorFromTxt(string mazeFilePath)
        {
            _mazeFilePath = mazeFilePath;
        }

        /// <summary>
        /// generates a valid maze using the txt file given
        /// </summary>
        /// <returns>a Maze object (the map of the maze, height and width and start and goal node)</returns>
        public Maze GenerateMaze()
        {
            Readfile();               
            SetHeight();
            SetWidth();
            SetNodes();

            return new Maze(_width,_height, _nodes, _startNode, _goalNode);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Readfile()
        {
            _lines = File.ReadAllLines(_mazeFilePath);

            if (_lines.Length == 0)
                throw new Exception(Messages.EmptyFile);            
        }
        
        private void SetHeight()
        {
            _height = _lines.Length;
        }

        private void SetWidth()
        {
            _width = _lines[0].Length;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetNodes()
        {           
            _nodes = new Node[_height, _width];

            for (int y=0; y<_lines.Length; y++)
            {
                Console.WriteLine(_lines[y]);

                char[] characters = _lines[y].ToCharArray();

                //checks if all lines have the same length
                if (characters.Length != _width)
                    throw new Exception(Messages.InvalidLines);

                for (int x = 0; x < characters.Length; x++)              
                {
                    char cell = characters[x];

                    //checks that maze txt consists from thevalid notations
                    if (Enum.IsDefined(typeof(NodeType), (int)cell))
                    {
                        Node newNode = new Node(new Point(x,y),(NodeType)cell);


                        if (newNode.Type == NodeType.Start)
                        {
                            //if exists we have more tha one start node
                            if (_startNode == null)
                                _startNode = newNode;
                            else
                                throw new Exception(Messages.UniqueStart);
                        }

                        if (newNode.Type == NodeType.Goal)
                        {
                            //if exists we have more tha one goal node
                            if (_goalNode == null)
                                _goalNode = newNode;
                            else
                                throw new Exception(Messages.UniqueGoal);
                        }

                        _nodes[y, x] = newNode;

                    }
                    else
                    {
                        throw new Exception(String.Format(Messages.InvalidBlock, cell.ToString()));
                    }
                }
            }

            //checks if start node exists
            if (_startNode == null)
                throw new Exception(Messages.NoStart);

            //checks if goal node exists
            if (_goalNode == null)
                throw new Exception(Messages.NoGoal);
        }

    }
}
