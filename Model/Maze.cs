namespace Model
{
    public class Maze
    {
        public Maze(int width, int height, Node[,] nodes, Node startNode, Node goalNode)
        {
            Width = width;
            Height = height;
            Nodes = nodes;
            StartNode = startNode;
            GoalNode = goalNode;
        }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Node[,] Nodes { get; private set; }
        public Node StartNode { get; private set; }
        public Node GoalNode { get; private set; }
    }
}
