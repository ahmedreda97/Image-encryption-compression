using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageQuantization
{
    [Serializable]
    class Node
    {
        public Node Left;
        public Node Right;
        public int Color;
        public uint Value;
        
        public Node(int color, uint value)
        {
            Color = color;
            Value = value;
        }
        public Node(Node left, Node right)
        {
            Left = left;
            Right = right;
            Value = left.Value + right.Value;
            Color = 0;
        }
    }
}
