using System.Drawing;

namespace Model
{
    public class Node
    {
        public Node(Point coordinates, NodeType type)
        {
            Coordinates = coordinates;
            Type = type;
           
        }
        public NodeType Type { get; private set; }
        public Point Coordinates { get; private set; }
    }
}
