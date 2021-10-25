using System;

namespace Lab1
{
    internal class Program
    {
        static void Message(string arg)
        {
            Console.WriteLine(arg);
        }
        private static void Main(string[] args)
        {
            MyQueque<int> queueNumbers = new MyQueque<int>();
            queueNumbers.Notification += Message;

            for (int i = 0; i < 7; i++)
            {
                queueNumbers.Enqueue(i);   //add numbers from 1 to 7 in the Queue
            }

            Console.WriteLine("Number's amount - " + queueNumbers.Count);

            Console.Write("Queue: ");
            foreach (var item in queueNumbers)
            {
                Console.Write($"{item} ");  //Iterate our collection
            }
            Console.WriteLine();

            int firstElement = queueNumbers.Dequeue();  //Delete first element (returns 0)
            Console.WriteLine("Number's amount after Dequeue() - " + queueNumbers.Count);

            Console.Write("Queue after Dequeue(): ");
            foreach (var item in queueNumbers)
            {
                Console.Write($"{item} ");  //Iterate our collection
            }
            Console.WriteLine();
            queueNumbers.Clear();

            Console.WriteLine("Number's amount after Clear() - " + queueNumbers.Count);

            Console.ReadKey();
        }
    }
}
