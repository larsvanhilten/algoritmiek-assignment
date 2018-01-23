using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Kd_Tree
{
    class EmptyKdNode<T> : IKdNode<T>
    {
        public bool isEmpty
        {
            get
            {
                return true;
            }
        }

        public Tuple<T, T> key
        {
            get
            {
                throw new Exception("Node Is Empty and has no value!");
            }
        }

        public IKdNode<T> left
        {
            get
            {
                throw new Exception("Node Is Empty and has no left!");
            }
        }

        public IKdNode<T> right
        {
            get
            {
                throw new Exception("Node Is Empty and has no right!");
            }
        }
    }
}
