using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Public;
using System.IO;
using System.Reflection;
using Model;

namespace MazeManager
{
    [TestClass]
    public class MazeGeneratorFromTxtTest
    {

        [TestMethod]
        public void GenerateMaze_ValidMazeFile_ReturnMaze()
        {
            /*
            ____G__X
            ___XXX__
            X______X
            __XXXX__
            ___X____
            __S__X__

            */
            int mazeHeight = 6;
            int mazeWidth = 8;
            int StartNodeX = 2;
            int StartNodeY = 5;
            int GoalNodeX = 4;
            int GoalNodeY = 0;
            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_Valid_Maze.txt");

            var maze = mazeGen.GenerateMaze();

            Assert.AreEqual(mazeHeight, maze.Height);
            Assert.AreEqual(mazeWidth, maze.Width);
            Assert.AreEqual(StartNodeX, maze.StartNode.Coordinates.X);
            Assert.AreEqual(StartNodeY, maze.StartNode.Coordinates.Y);
            Assert.AreEqual(NodeType.Start, maze.StartNode.Type);
            Assert.AreEqual(GoalNodeX, maze.GoalNode.Coordinates.X);
            Assert.AreEqual(GoalNodeY, maze.GoalNode.Coordinates.Y);
            Assert.AreEqual(NodeType.Goal, maze.GoalNode.Type);
            Assert.AreEqual(mazeHeight, maze.Nodes.GetLength(0));
            Assert.AreEqual(mazeWidth, maze.Nodes.GetLength(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_EmptyMazeFile_ThrowException()
        {
            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_Empty_Maze.txt");

            var maze = mazeGen.GenerateMaze();
           
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_InvalidLinesMazeFile_ThrowException()
        {
            /*
            
            ____G__XX
            ___XXX__
            X______X_
            __XXXX__
            ___X____
            __S__X__
            
            */

            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_InValidLines_Maze.txt");

            var maze = mazeGen.GenerateMaze();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_InvalidNotationMazeFile_ThrowException()
        {
            /*
            
                ____G__X
                _J_XXX__
                X______X
                __XXXX__
                ___X____
                __S__X__
            
            */

            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_InvalidNotation_Maze.txt");

            var maze = mazeGen.GenerateMaze();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_NoStartMazeFile_ThrowException()
        {
            /*
            
                ____G__X
                ___XXX__
                X______X
                __XXXX__
                ___X____
                __X__X__
            
            */

            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_NoStart_Maze.txt");

            var maze = mazeGen.GenerateMaze();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_NoGoalMazeFile_ThrowException()
        {
            /*
            
                _______X
                ___XXX__
                X______X
                __XXXX__
                ___X____
                __S__X__
            
            */

            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_NoGoal_Maze.txt");

            var maze = mazeGen.GenerateMaze();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_MoreThanOneGoalMazeFile_ThrowException()
        {
            /*
            
                ____G__X
                ___XXX__
                X______X
                __XXXX__
                ___X____
                __G__X__            
            */

            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_MoreThanOneGoal_Maze.txt");

            var maze = mazeGen.GenerateMaze();

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GenerateMaze_MoreThanOneStartMazeFile_ThrowException()
        {
            /*
                ____S__X
                ___XXX__
                X______X
                __XXXX__
                ___X____
                __S__X__           
            */

            var mazeGen = ProvideMazeGenerator(@"TestMazefiles\Test_MoreThanOneStart_Maze.txt");

            var maze = mazeGen.GenerateMaze();

        }

        static ICanBuildMaze ProvideMazeGenerator(string path)
        {

            string solutionPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);

            return new MazeGeneratorFromTxt(solutionPath);
        }

    }


}