using System;
using System.Collections;
using System.Collections.Generic;

namespace Permutation
{
    public class PermutableData
    {
        public PermutableData()
        {
            
        }
    }

    public class MyData<T> : IEnumerable,IEnumerator where T:IComparable
    {
        T[] array;
        uint size;
        uint capacity;

        public MyData()
        {
            array = new T[1];
            array[0] = default(T);
            size = 1;
            capacity = 1;
        }

        public MyData(uint i)
        {
            array = new T[i];
            for (int j = 0; j < i; j++)
            {
                array[j] = default(T);
            }
            size = i;
            capacity = i;
        }

        public MyData(IEnumerable<T> collection)
        {
            if (null!=collection)
            {
                using (IEnumerator<T> en = collection!.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Add(en.Current);
                    }
                }
            }
        }

        public T this[uint i]
        {
            get
            {
                return array[i];
            }
            set
            {
                if (i>=size)
                {
                    throw new Exception("Out of length!!!");
                }
                array[i] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }


        int position = -1;

        public object Current
        {
            get
            {
                return array[position];
                
            }
            
        }

        public bool MoveNext()
        {
            position++;
            return position < array.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Add(T item)
        {
            if ((uint)size < (uint)array.Length)
            {
                ++size;
                array[size] = item;
            }
            else
            {
                AddWithResizeByOne(item);
            }
        }

        private void AddWithResizeByOne(T item)
        {
            Resize(size + 1);
            array[size] = item;
            ++size;
        }

        private void Resize(uint temp = 0)
        {
            uint newCapacity = 0 == capacity ? 1 : capacity * 2;
            if (newCapacity<temp)
            {
                newCapacity = temp;
            }
            T[] newArray = new T[newCapacity];
            if (size>0)
            {
                Array.Copy(array, newArray, size);

            }
            array = newArray;
            capacity = newCapacity;
        }


    }
}
