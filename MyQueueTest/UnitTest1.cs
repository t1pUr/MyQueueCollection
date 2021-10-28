using Lab1;
using NUnit.Framework;
using System;

namespace MyQueueTest
{
    public class Tests
    {
        MyQueque<int> emptyQueue;
        MyQueque<int> queue;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountEmpty()
        {
            emptyQueue = new MyQueque<int>();

            int elementsNumber = emptyQueue.Count;

            Assert.AreEqual(elementsNumber, 0, message: "Test the number of elements in an empty collection");

            try
            {
                emptyQueue.Dequeue();
            }
            catch(InvalidOperationException)   //try to delete the first element in the empty collection
            {
                return;
            }
        }

        [Test]
        public void ContainsEmpty()
        {
            emptyQueue = new MyQueque<int>();

            Assert.AreEqual(emptyQueue.Contains(4), false, message: "Test Contains() method in an empty collection");
        }

        [Test]
        public void CountReturn1()
        {
            queue = new MyQueque<int>();

            queue.Enqueue(100);

            Assert.AreEqual(queue.Count, 1, message: "Test the number of elements in n nonempty collection");
        }

        [Test]
        public void AddSeveralStringElementsAndDequeue()
        {
            MyQueque<string> testQueue = new MyQueque<string>();



            for (int i = 0; i < 10; i++)
            {
                testQueue.Enqueue(string.Format($"Number {i}")); //Number 0 ... Number 9
            }

            int countBeforeDequeue = testQueue.Count;
            string firstElement = testQueue.Dequeue();

            if (!testQueue.TryDequeue(out string elem))
                throw new ArgumentNullException();

            Assert.AreEqual(firstElement, "Number 0", message: "Test that Dequeue() method must delete the first element and return him");
            Assert.AreEqual(testQueue.Count, countBeforeDequeue - 2, message: "After dequeue collection's elements became 2 less");
        }

        [Test]
        public void PeekTest()
        {
            MyQueque<double> myQueue = new MyQueque<double>();

            for (double i = 1; i < 10; i += 1)
            {
                myQueue.Enqueue(i); // 1 2 3 ... 9
            }
            int countPeek = myQueue.Count;

            double firstElem = 0;
            if (myQueue.TryPeek(out double elem))
                firstElem = myQueue.Peek();
            

            Assert.AreEqual(Math.Ceiling(firstElem), 1, message: "After Peek() returns first element");
            Assert.AreEqual(countPeek, myQueue.Count, message: "After Peek() collection's counts doesn't change");
        }

        [TestCase(100, 200, 300, 400, 500)]
        [TestCase(232, 487, 348, 8843)]
        public void ToArrayTest(params int[] numbers)
        {
            MyQueque<int> myQueue = new MyQueque<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                myQueue.Enqueue(numbers[i]);
            }

            Assert.AreEqual(myQueue.ToArray(), numbers, message: "Array and MyQueue.ToArray() must be equal");
        }

        [Test]
        public void TestCopyto()
        {
            MyQueque<int> myQueue = new MyQueque<int>();
            int[] numbers = new int[10];

            for (int i = 1; i < 8; i++)
            {
                myQueue.Enqueue(i);
            }

            myQueue.CopyTo(numbers, 3);

            Assert.AreEqual(numbers, new int[] { 0, 0, 0, 1, 2, 3, 4, 5, 6, 7 }, message: "Arrays after CopyTo() method must be equal");

            try
            {
                myQueue.CopyTo(numbers, -2);
            }
            catch(ArgumentOutOfRangeException)
            {
                return;
            }
        }

        [TestCase(100, 200, 300, 400, 500)]
        [TestCase(232, 487, 3448, 8843, 1000)]
        public void TestClear(params int[] numbers)
        {
            MyQueque<int> myQueue = new MyQueque<int>();

            for (int i = 1; i < numbers.Length; i++)
            {
                myQueue.Enqueue(numbers[i]);
            }

            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }

            myQueue.Clear();

            Assert.AreEqual(myQueue.Count, 0, message: "Collection's count must be zero && foreach test");
        }

        [Test]
        public void TestCapacity()
        {
            try
            {
                MyQueque<int> myQueue = new MyQueque<int>(-4);
            }
            catch(ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail("No exception was thrown");

        }

    }
}