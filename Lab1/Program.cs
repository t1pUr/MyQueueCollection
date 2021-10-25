using System;

namespace Lab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyQueque<int> myQueque = new MyQueque<int>(10);
            Console.WriteLine("Dequeued: - " + myQueque.TryDequeue(out int _).ToString());
            myQueque.Enqueue(4);
            myQueque.Enqueue(5);
            myQueque.Enqueue(6);
            Console.WriteLine(myQueque.Count);
            Console.WriteLine(string.Format("{0}  {1}", (object)myQueque.Dequeue(), (object)myQueque.Count));
            Console.WriteLine(myQueque.Peek());
            Console.WriteLine(new string('_', 10));
            foreach (int num in myQueque.ToArray())
                Console.WriteLine(num);
            Console.WriteLine(myQueque.Contains(5));
            Console.WriteLine(myQueque.Contains(1));
            myQueque.Clear();
            foreach (int num in myQueque.ToArray())
                Console.WriteLine(num);

            Console.WriteLine(new string('_', 20));
            MyQueque<int> myQueque1 = new MyQueque<int>();
            Console.WriteLine(myQueque1.Count);
            myQueque1.Enqueue(10);
            myQueque1.Enqueue(20);
            myQueque1.Enqueue(30);
            myQueque1.Enqueue(40);
            foreach (var item in myQueque1)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
