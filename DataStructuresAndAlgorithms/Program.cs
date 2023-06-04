namespace DataStructuresAndAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var a = new DoublyLinkedList<int>();
            a.AddLast(4);
            a.AddLast(3);
            a.AddLast(2);
            a.AddLast(1);
            var n = a.First;
            Console.WriteLine(a.Contains(3));
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
             
        }
    }
}