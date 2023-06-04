using System.Collections;

namespace DataStructuresAndAlgorithms;

public class LinkedList<T> : ICollection<T>, ICollection
{
    public int Count { get; private set; }
    public bool IsSynchronized => false;
    public object SyncRoot => this;

    public bool IsReadOnly => false;

    private Node<T> _head;
    private Node<T> _tail;

    public LinkedList()
    {
    }

    /// <summary>
    /// Adds a node to the end of the Linkedlist
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        AddLast(item);
    }

    public void AddLast(T item)
    {
        var node = new Node<T>(item);
        Count++;
        if (_head == null && _tail == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            _tail.Next = node;
            _tail = node;
        }
    }

    public void AddFirst(T item)
    {
        var node = new Node<T>(item);
        Count++;
        node.Next = _head;
        _head = node;
        if (Count == 0)
        {
            _head = node;
            _tail = node;
        }
    }


    public void Clear()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var node = _head;
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
        var node = _head;
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
        var currentNode = _head;
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
                        _tail = previous;
                    }
                }
                else
                {
                    _head = _head?.Next;
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

    private class LinkedListEnumerator : IEnumerator<T>
    {
        private readonly LinkedList<T> _linkedList;
        private int _index = -1;
        private Node<T> _node;
        private T? _current;

        public LinkedListEnumerator(LinkedList<T> list)
        {
            _linkedList = list;
            _node = list._head;
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
            _node = _linkedList._head;
            _index = -1;
        }

        public T Current => _current;

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

    public class Node<T>
    {
        public Node<T>? Next;

        public T Value;

        public Node(T value)
        {
            Value = value;
        }
    }
}