using Model;
using System.Collections.Generic;

namespace Public
{
    public interface ICanSolveMaze
    {
        List<List<Node>> FindPaths(Maze maze);
    }
}
