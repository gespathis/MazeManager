using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Public;
using System.IO;
using System.Reflection;
using Model;
using System.Drawing;
using System.Collections.Generic;

namespace MazeManager
{
    [TestClass]
    public class MazeSolverTest
    {

        [TestMethod]
        public void FindPaths_Maze_ReturnAllPaths()
        {

            int maxPathsFind = 100;
            int expectedRows = 37;
            MazeSolver mazesolver = new MazeSolver(maxPathsFind);

            List<List<Node>> _paths = mazesolver.FindPaths(ProvideMazewithPaths());

            Assert.AreEqual(expectedRows, _paths.Count);
         }

        [TestMethod]
        public void FindPaths_Maze_ReturnOnePath()
        {

            int maxPathsFind = 1;
            int expectedRows = 1;
            MazeSolver mazesolver = new MazeSolver(maxPathsFind);

            List<List<Node>> _paths = mazesolver.FindPaths(ProvideMazewithPaths());

            Assert.AreEqual(expectedRows, _paths.Count);
        }


        [TestMethod]
        public void FindPaths_Maze_ReturnNoPath()
        {

            int maxPathsFind = 100;
            int expectedRows = 0;
            MazeSolver mazesolver = new MazeSolver(maxPathsFind);

            List<List<Node>> _paths = mazesolver.FindPaths(ProvideMazewithNoPaths());

            Assert.AreEqual(expectedRows, _paths.Count);
        }

        static Maze ProvideMazewithPaths()
        {
            int width = 6;
            int height = 4;
            Node goalNode = new Node(new Point(2, 0), NodeType.Goal);
            Node startNode = new Node(new Point(0, 3), NodeType.Start); 

            Node[,] matrixNode= new Node[height, width];

            matrixNode[0, 0] = new Node(new Point(0, 0), NodeType.Empty);
            matrixNode[0, 1] = new Node(new Point(1, 0), NodeType.Empty);
            matrixNode[0, 2] = goalNode;
            matrixNode[0, 3] = new Node(new Point(3, 0), NodeType.Empty);
            matrixNode[0, 4] = new Node(new Point(4, 0), NodeType.Empty);
            matrixNode[0, 5] = new Node(new Point(5, 0), NodeType.Wall);

            matrixNode[1, 0] = new Node(new Point(0, 1), NodeType.Empty);
            matrixNode[1, 1] = new Node(new Point(1, 1), NodeType.Empty);
            matrixNode[1, 2] = new Node(new Point(2, 1), NodeType.Empty);
            matrixNode[1, 3] = new Node(new Point(3, 1), NodeType.Empty);
            matrixNode[1, 4] = new Node(new Point(4, 1), NodeType.Empty);
            matrixNode[1, 5] = new Node(new Point(5, 1), NodeType.Wall);

            matrixNode[2, 0] = new Node(new Point(0, 2), NodeType.Empty);
            matrixNode[2, 1] = new Node(new Point(1, 2), NodeType.Wall);
            matrixNode[2, 2] = new Node(new Point(2, 2), NodeType.Empty);
            matrixNode[2, 3] = new Node(new Point(3, 2), NodeType.Empty);
            matrixNode[2, 4] = new Node(new Point(4, 2), NodeType.Empty);
            matrixNode[2, 5] = new Node(new Point(5, 2), NodeType.Empty);

            matrixNode[3, 0] = startNode;
            matrixNode[3, 1] = new Node(new Point(1, 3), NodeType.Empty);
            matrixNode[3, 2] = new Node(new Point(2, 3), NodeType.Empty);
            matrixNode[3, 3] = new Node(new Point(3, 3), NodeType.Wall);
            matrixNode[3, 4] = new Node(new Point(4, 3), NodeType.Empty);
            matrixNode[3, 5] = new Node(new Point(5, 3), NodeType.Empty);

            Maze newMaze = new Maze(width, height, matrixNode, startNode, goalNode);


            return newMaze;
        }

        static Maze ProvideMazewithNoPaths()
        {
            int width = 6;
            int height = 4;
            Node goalNode = new Node(new Point(2, 0), NodeType.Goal);
            Node startNode = new Node(new Point(0, 3), NodeType.Start);

            Node[,] matrixNode = new Node[height, width];

            matrixNode[0, 0] = new Node(new Point(0, 0), NodeType.Empty);
            matrixNode[0, 1] = new Node(new Point(1, 0), NodeType.Empty);
            matrixNode[0, 2] = goalNode;
            matrixNode[0, 3] = new Node(new Point(3, 0), NodeType.Empty);
            matrixNode[0, 4] = new Node(new Point(4, 0), NodeType.Empty);
            matrixNode[0, 5] = new Node(new Point(5, 0), NodeType.Wall);

            matrixNode[1, 0] = new Node(new Point(0, 1), NodeType.Wall);
            matrixNode[1, 1] = new Node(new Point(1, 1), NodeType.Wall);
            matrixNode[1, 2] = new Node(new Point(2, 1), NodeType.Wall);
            matrixNode[1, 3] = new Node(new Point(3, 1), NodeType.Wall);
            matrixNode[1, 4] = new Node(new Point(4, 1), NodeType.Wall);
            matrixNode[1, 5] = new Node(new Point(5, 1), NodeType.Wall);

            matrixNode[2, 0] = new Node(new Point(0, 2), NodeType.Empty);
            matrixNode[2, 1] = new Node(new Point(1, 2), NodeType.Wall);
            matrixNode[2, 2] = new Node(new Point(2, 2), NodeType.Empty);
            matrixNode[2, 3] = new Node(new Point(3, 2), NodeType.Empty);
            matrixNode[2, 4] = new Node(new Point(4, 2), NodeType.Empty);
            matrixNode[2, 5] = new Node(new Point(5, 2), NodeType.Empty);

            matrixNode[3, 0] = startNode;
            matrixNode[3, 1] = new Node(new Point(1, 3), NodeType.Empty);
            matrixNode[3, 2] = new Node(new Point(2, 3), NodeType.Empty);
            matrixNode[3, 3] = new Node(new Point(3, 3), NodeType.Wall);
            matrixNode[3, 4] = new Node(new Point(4, 3), NodeType.Empty);
            matrixNode[3, 5] = new Node(new Point(5, 3), NodeType.Empty);

            Maze newMaze = new Maze(width, height, matrixNode, startNode, goalNode);


            return newMaze;
        }

    }


}