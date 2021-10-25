using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1
{
  internal class MyQueque<T>
  {
    private Element<T>[] elements;
    private int count;

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

    public int Count
        {
            get
            {
                return count;
            }
        }

    public void Clear()
    {
      elements = new Element<T>[0];
      count = 0;
    }

    public bool Contains(T elem)
    {
      bool flag = false;
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
        array[index] = elements[index].Data;
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
      return data;
    }

        public T Peek() 
        {
            return elements[0].Data;
        }

    public T[] ToArray()
    {
      T[] objArray = new T[count];
      for (int index = 0; index < objArray.Length; index++)
        objArray[index] = elements[index].Data;
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
        result = default (T);
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


  }
}
