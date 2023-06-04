using System.Collections;

namespace DataStructuresAndAlgorithms;

public class DoublyLinkedList<T> : ICollection<T>, ICollection
{
    public int Count { get; set; }
    public bool IsSynchronized => false;
    public object SyncRoot => this;
    public bool IsReadOnly => false;

    private DoublyLinkedListNode<T>? _head;
    private DoublyLinkedListNode<T>? _tail;

    public DoublyLinkedListNode<T>? First => _head;

    public DoublyLinkedListNode<T>? Last => _tail;

    public void Add(T item)
    {
        AddLast(item);
    }

    public void AddLast(T item)
    {
        var node = new DoublyLinkedListNode<T>(item);
        Count++;
        if (_head == null && _tail == null)
        {
            _head = node;
            _tail = node;
        }

        _tail.Next = node;
        node.Previous = _tail;
        _tail = node;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
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
            var equality = EqualityComparer<T>.Default;
            if (node.Value != null && equality.Equals(node.Value, item))
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
        var node = _head;
        var equality = EqualityComparer<T>.Default;
        while (node != null && item != null)
        {
            if (equality.Equals(item, node.Value))
            {
                if (node.Previous == null)
                {
                    _head = _head.Next;
                    _head.Previous = null;
                    Count--;
                    return true;
                }

                if (node.Next == null)
                {
                    _tail = _tail.Previous;
                    _tail.Next = null;
                    Count--;
                    return true;
                }

                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                Count--;
                return true;
            }


            node = node.Next;
        }

        return false;
    }


    public IEnumerator<T> GetEnumerator()
    {
        var node = _head;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class DoublyLinkedListNode<T>
{
    public DoublyLinkedListNode<T>? Next;
    public DoublyLinkedListNode<T>? Previous;

    public readonly T Value;

    public DoublyLinkedListNode(T value)
    {
        Value = value;
    }
}