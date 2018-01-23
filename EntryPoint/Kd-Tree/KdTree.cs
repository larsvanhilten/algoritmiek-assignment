using EntryPoint.Kd_Tree;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.KD_Tree
{
    class KdTree
    {
        private IKdNode<float> root;
        public KdTree() {
            root = new EmptyKdNode<float>() as IKdNode<float>;
        }
        public void Insert(Tuple<float, float> key) {
            root = InsertRec(root, key, -1);
        }

        private IKdNode<float> InsertRec(IKdNode<float> root, Tuple<float, float> key, int dimension) {
            dimension++;

            if (root.isEmpty) {
                return new KdNode<float>(key, new EmptyKdNode<float>(), new EmptyKdNode<float>());
            }

            if (dimension % 2 == 0)
            {
                if (root.key.Item1 > key.Item1)
                    return new KdNode<float>(root.key, InsertRec(root.left, key, dimension), root.right);
                else
                    return new KdNode<float>(root.key, root.left, InsertRec(root.right, key, dimension));
            }
            else {
                if (root.key.Item2 > key.Item2)
                    return new KdNode<float>(root.key, InsertRec(root.left, key, dimension), root.right);
                else
                    return new KdNode<float>(root.key, root.left, InsertRec(root.right, key, dimension));
            }
        }

        public IEnumerable<Vector2> GetAllNodesWithinDistance(Vector2 startPosition, float distance) {
            return GetAllNodesWithinDistance(root, startPosition, distance);
        }

        private IEnumerable<Vector2> GetAllNodesWithinDistance(IKdNode<float> root, Vector2 startPosition, float distance) {
            List<Vector2> foundNodes = new List<Vector2>();

            Queue<IKdNode<float>> queue = new Queue<IKdNode<float>>();
            queue.Enqueue(root);

            while (queue.Count > 0) {
                IKdNode<float> currentNode = queue.Dequeue();
                if (currentNode.isEmpty)
                    continue;
                if (Vector2.Distance(startPosition, new Vector2(currentNode.key.Item1, currentNode.key.Item2)) <= distance)
                    foundNodes.Add(new Vector2(currentNode.key.Item1, currentNode.key.Item2));
                queue.Enqueue(currentNode.left);
                queue.Enqueue(currentNode.right);
            }

            return foundNodes;
        }
    }
}
