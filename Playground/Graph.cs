using System;
using System.Collections.Generic;

namespace Playground
{
    public class Graph
    {
        private class Node
        {
            public int value;
            public Node left;
            public Node right;
        }

        private static void printBreathFirst(Node root)
        {
            Queue<Node> nodesToVisit = new Queue<Node>();
            
            nodesToVisit.Enqueue(root);
            while (nodesToVisit.Count > 0)
            {
                var visited = nodesToVisit.Dequeue();
                Console.WriteLine($"{visited.value} ");

                if (visited.left != null)
                {
                    nodesToVisit.Enqueue(visited.left);
                }
                if (visited.right != null)
                {
                    nodesToVisit.Enqueue(visited.right);
                }
            }
        }


        public static void Main()
        {
            //         7
            //      4       9
            //    2   6   8    11
            //  1                   13
            var root = new Node
            {
                value = 7,
                left = new Node
                {
                    value = 4,
                    left = new Node
                    {
                        value = 2,
                        left = new Node {
                            value = 1
                        }
                    },
                    right = new Node
                    {
                        value = 6
                    }
                },
                right = new Node
                {
                    value = 9,
                    left = new Node
                    {
                        value = 8
                    },
                    right = new Node
                    {
                        value = 11,
                        right = new Node
                        {
                            value = 13
                        }
                    }
                }
            };
            
            printBreathFirst(root);
        }
        
    }
}