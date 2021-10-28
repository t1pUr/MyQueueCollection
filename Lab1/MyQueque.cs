using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lab1
{
    /// <summary>
    /// Represents a first-in, first-out collection of objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class MyQueque<T> : IEnumerable<T>
    {
        private Element<T>[] elements;
        private int count;

        public delegate void Message(string mes);
        public event Message Notification;

        public MyQueque(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            this.elements = new Element<T>[1];
        }

        public MyQueque()
        {
            elements = new Element<T>[1];
        }
        /// <summary>
        /// Gets the number of elements contained in the MyQueue collection.
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }
        /// <summary>
        /// Removes all objects from the MyQueue collection
        /// </summary>
        public void Clear()
        {
            elements = new Element<T>[0];
            count = 0;
            Notification?.Invoke("The Queue is cleared");
        }
        /// <summary>
        /// Determines whether an element is in the MyQueue collection.
        /// </summary>
        /// <param name="elem">The object to locate in the MyQueue collection. The value can be null for reference types.</param>
        /// <returns>true if item is found in the MyQueue collection; otherwise, false.</returns>
        public bool Contains(T elem)
        {
            bool flag = false;
            if (count == 0)
                return flag;
            for (int index = 0; index < elements.Length; ++index)
            {
                if (Equals(elements[index].Data, elem))
                    flag = true;
            }
            return flag;
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array == null)
                throw new ArgumentNullException();
            if (count > array.Length - arrayIndex)
                throw new ArgumentException();
            for (int index = arrayIndex; index < array.Length; ++index)
                array[index] = elements[index - arrayIndex].Data;
        }

        public void Enqueue(T item)
        {
            Element<T>[] elementArray = new Element<T>[this.count + 1];
            if (count > 0)
            {
                for (int index = 0; index < elements.Length; ++index)
                    elementArray[index] = elements[index];
            }
            elementArray[elementArray.Length - 1] = new Element<T>(item);
            elements = elementArray;
            count++;
            Notification?.Invoke($"The element {item} was added to the Queue"); //
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T data = elements[0].Data;
            Element<T>[] elementArray = new Element<T>[count - 1];
            for (int index = 0; index < elementArray.Length; ++index)
            {
                elementArray[index] = elements[index + 1];
            }

            elements = elementArray;
            count--;
            Notification?.Invoke($"The first element {data} was dequeued from the Queue");
            return data; 
        }

        public T Peek()
        {
            if (count == 0)
                throw new InvalidOperationException();
            return elements[0].Data;
        }

        public T[] ToArray()
        {
            T[] objArray = new T[count];
            for (int index = 0; index < objArray.Length; index++)
                objArray[index] = elements[index].Data;
            Notification?.Invoke("The Queue was moved to Array");
            return objArray;
        }
        public void TrimExcess()
        {
            //In this case this method doing nothing
        }

        public bool TryDequeue([MaybeNullWhen(false)] out T result)
        {
            if (count == 0)
            {
                result = default(T);
                return false;
            }
            result = Dequeue();
            return true;
        }

        public bool TryPeek([MaybeNullWhen(false)] out T result)
        {
            if (count == 0)
            {
                result = default(T);
                return false;
            }
            result = Peek();
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return elements[i].Data;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return ((IEnumerable)this).GetEnumerator();
        }
    }
}
