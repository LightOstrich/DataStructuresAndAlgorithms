namespace DataStructuresAndAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var b = new List<int>();
            var a = new DynamicArray<int>
            {
                5,
                4,
                3,
                2,
                1,
                11,
                12,
                13,
                15
            };
            var c = a.GetEnumerator();
            foreach (var o in a)
            {
                Console.WriteLine(o);
            }
        }
    }
}