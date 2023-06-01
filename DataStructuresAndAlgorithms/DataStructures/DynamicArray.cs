using System.Collections;

namespace DataStructuresAndAlgorithms
{
    public class DynamicArray<T> : ICollection
    {
        public int Count => _count;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        private const int DEFAULT_COUNT_OF_DYNAMICARRAY = 4;
        private T?[] _array;
        private int _count = 0;

        public int Capacity
        {
            get => _array.Length;
            set => _count = value; //исправить
        }

        public T? Get(int index)
        {
            return _array[index];
        }

        public T? this[int index] => _array[index];

        public DynamicArray()
        {
            _array = new T[DEFAULT_COUNT_OF_DYNAMICARRAY];
        }

        public DynamicArray(int capacity)
        {
            _array = capacity switch
            {
                < 0 => throw new ArgumentOutOfRangeException($"Capacity is not been less then zero"),
                0 => new T[DEFAULT_COUNT_OF_DYNAMICARRAY],
                _ => new T[capacity]
            };
        }

        public void Add(T? value)
        {
            if (_count < _array.Length)
            {
                _array[_count] = value;
                _count++;
            }
            else
            {
                Resize(value);
            }
        }

        private void Resize(T? value)
        {
            T?[] temp = new T[_array.Length * 2];
            for (var i = 0; i < _array.Length; i++)
            {
                temp[i] = _array[i];
            }

            _array = temp;
            _array[_count++] = value;
        }


        public void CopyTo(Array array, int index)
        {
            Array.Copy(_array, 0, array, index, Count);
        }

        public IEnumerator GetEnumerator()
        {
            return new DynamicArrayEnumerator(this);
        }

        private class DynamicArrayEnumerator : IEnumerator
        {
            private readonly DynamicArray<T?> _dynamicArray;
            private int _index = -1;

            public DynamicArrayEnumerator(DynamicArray<T?> dynamicArray)
            {
                _dynamicArray = dynamicArray;
            }

            public bool MoveNext()
            {
                _index++;
                return _dynamicArray.Count > _index;
            }

            public void Reset()
            {
                _index = -1;
            }

            public object? Current => _dynamicArray.Get(_index);
        }
    }
}