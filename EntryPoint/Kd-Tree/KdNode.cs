using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Kd_Tree
{
    class KdNode<T> : IKdNode<T>
    {
        public bool isEmpty
        {
            get
            {
                return false;
            }
        }

        public Tuple<T, T> key { get; set; }
        public IKdNode<T> left { get; set; }
        public IKdNode<T> right { get; set; }

        public KdNode(Tuple<T,T> key, IKdNode<T> left, IKdNode<T> right) {
            this.key = key;
            this.left = left;
            this.right = right;
        }
    }
}
