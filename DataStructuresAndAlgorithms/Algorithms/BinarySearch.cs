using System.Collections;

namespace DataStructuresAndAlgorithms
{
    /// <summary>
    /// Only works with sorting Enumerable Collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearch<T> where T : IComparable<T>
    {
        private readonly IEnumerable<T?> _collection;

        public BinarySearch(IEnumerable<T?> collection)
        {
            _collection = collection;
        }

        /// <summary>
        /// Return a index of searching element
        /// else return default
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Search(T value)
        {
            var left = 0;
            var right = _collection.Count() - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (_collection.ElementAt(mid)!.CompareTo(value) == 0)
                {
                    return mid;
                }

                if (_collection.ElementAt(mid)!.CompareTo(value) < 0)
                {
                    left = mid + 1;
                }

                else if (_collection.ElementAt(mid)!.CompareTo(value) > 0)
                {
                    right = mid - 1;
                }
            }

            return default;
        }
    }
}