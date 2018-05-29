using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MazeManager
{
    public class MazeSolver : ICanSolveMaze
    {
        private Maze _maze;
        private List<List<Node>> _paths = new List<List<Node>>();
        private HashSet<Node> _badpaths = new HashSet<Node>();
        private int _maxPathsFound;

        public MazeSolver(int maxPathsFound)
        {
            _maxPathsFound = maxPathsFound;
        }
        public List<List<Node>> FindPaths(Maze maze)
        {
            if (maze != null)
            {
                _maze = maze;

                List<Node> newpath = new List<Node>();
                Search(_maze.StartNode, newpath);

            }

            return _paths;
        }

        private void Search(Node currentNode, List<Node> path)
        {

            List<Node> localPath = new List<Node>(path);
            localPath.Add(currentNode);

            if (currentNode.Type == NodeType.Goal)
            {
                _paths.Add(localPath);
                return;
            }

            IList<Node> availableNodes = GetAvailableNodes(currentNode, localPath);

            if (availableNodes.Count == 0)
                _badpaths.Add(currentNode);

            foreach (Node node in availableNodes)
            {
                if (_paths.Count < _maxPathsFound)
                {
                    Search(node, localPath);
                }
            }
        }

        private IList<Node> GetAvailableNodes(Node currentNode, List<Node> path)
        {
            IList<Node> availableNodes = new List<Node>();
            IList<Point> moves = GetMovements(currentNode.Coordinates.X, currentNode.Coordinates.Y, _maze.Width, _maze.Height);

            foreach (Point move in moves)
            {
                var node = _maze.Nodes[move.Y, move.X];

                if (node.Type != NodeType.Wall && !ExistsInPath(node, path) && !_badpaths.Contains(node))
                {
                    availableNodes.Add(node);
                }
            }

            return availableNodes;
        }

        private bool ExistsInPath(Node node, List<Node> path)
        {
            foreach (Node nodeInPath in path)
            {
                if (node == nodeInPath)
                {
                    return true;
                }
            }
            return false;
        }
        private static IList<Point> GetMovements(int currentX, int currentY, int maxWidth, int maxHeight)
        {
            List<Point> movements = new List<Point>();

            //UP
            if (currentY - 1 >= 0)
                movements.Add(new Point(currentX, currentY - 1));

            //DOWN
            if (currentY + 1 < maxHeight)
                movements.Add(new Point(currentX, currentY + 1));

            //LEFT
            if (currentX - 1 >= 0)
                movements.Add(new Point(currentX - 1, currentY));

            //RIGHT
            if (currentX + 1 < maxWidth)
                movements.Add(new Point(currentX + 1, currentY));

            return movements;
        }

    }
}
