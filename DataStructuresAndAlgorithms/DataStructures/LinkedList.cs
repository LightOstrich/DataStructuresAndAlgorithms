using System.Collections;

namespace DataStructuresAndAlgorithms;

public class LinkedList<T> : ICollection<T>, ICollection
{
    public int Count { get; private set; }
    public bool IsSynchronized => false;
    public object SyncRoot => this;

    public bool IsReadOnly => false;

    public Node<T> Head;
    public Node<T> Tail;

    public LinkedList()
    {
    }

    /// <summary>
    /// Adds a node to the end of the Linkedlist
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        var node = new Node<T>(item);
        Count++;
        if (Head == null && Tail == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            Tail = node;
        }
    }


    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var node = Head;
        if (item == null)
        {
            throw new NullReferenceException();
        }

        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(item))
            {
                return true;
            }

            node = node.Next;
        }

        return false;
    }

    public void CopyTo(T[]? array, int arrayIndex)
    {
        var node = Head;
        while (node != null)
        {
            if (array != null) array[arrayIndex++] = node.Value;
            node = node.Next;
        }
    }

    public void CopyTo(Array array, int index)
    {
        var tempArray = array as T[];
        CopyTo(tempArray, index);
    }


    public bool Remove(T item)
    {
        var currentNode = Head;
        Node<T> previous = null;
        while (currentNode != null && item != null)
        {
            if (currentNode.Value != null && currentNode.Value.Equals(item))
            {
                if (previous != null)
                {
                    previous.Next = currentNode.Next;
                    if (currentNode.Next == null)
                    {
                        Tail = previous;
                    }
                }
                else
                {
                    Head = Head?.Next;
                }

                Count--;
                return true;
            }

            previous = currentNode;
            currentNode = currentNode.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new LinkedListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LinkedListEnumerator : IEnumerator<T>, IEnumerator
    {
        private readonly LinkedList<T> _linkedList;
        private int _index = -1;
        private Node<T> _node;
        private T? _current;

        public LinkedListEnumerator(LinkedList<T> list)
        {
            _linkedList = list;
            _node = list.Head;
        }

        public bool MoveNext()
        {
            if (_node == null)
            {
                return false;
            }

            _current = _node.Value;
            _node = _node.Next;
            _index++;
            return true;
        }

        public void Reset()
        {
            _current = default;
            _node = _linkedList.Head;
            _index = -1;
        }

        public T? Current => _current;

        object? IEnumerator.Current
        {
            get
            {
                if (Current != null) return Current;
                return new NullReferenceException();
            }
        }

        public void Dispose()
        {
        }
    }
}

public class Node<T>
{
    public Node<T>? Next;

    public T Value;

    public Node(T value)
    {
        Value = value;
    }
}