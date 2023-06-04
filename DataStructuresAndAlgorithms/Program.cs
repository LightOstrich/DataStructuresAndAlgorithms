namespace DataStructuresAndAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var a = new LinkedList<int>();
            a.AddFirst(2);
            a.AddFirst(4);
            a.AddFirst(10);
            a.AddFirst(1);
            a.AddFirst(2);
            a.AddFirst(3);
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }
    }
}