using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Kd_Tree
{
    interface IKdNode<T>
    {
        bool isEmpty { get; }
        Tuple<T, T> key { get; }
        IKdNode<T> left { get; }
        IKdNode<T> right { get; }
    }
}
