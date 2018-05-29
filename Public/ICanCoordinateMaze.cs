using Model;
using System.Collections.Generic;

namespace Public
{
    public interface ICanCoordinateMaze
    {
        void MazePaths(out string errorMessage);
    }
}
