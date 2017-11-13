using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapWithGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var line1 = Console.ReadLine();
            String[] inputsStr = line1.Split();
            List<int> inputInt = new List<int>();
            foreach (String item in inputsStr)
            {
                inputInt.Add( int.Parse(item) );
            }
            Heap<int> testIt = new Heap<int>(inputInt);
            testIt.BuildHeap();
            Console.WriteLine(testIt.ToString());
            while(testIt.Count != 0)
            {
                Console.WriteLine("Now Popping");
                Console.WriteLine("Pop() returns " + testIt.Pop());
                Console.WriteLine(testIt.ToString());
            }
            
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private Heap<T> AllValues;

        public int Count { get { return AllValues.Count; } }

        public PriorityQueue()
        {
            AllValues = new Heap<T>(new List<T>());
        }

        public PriorityQueue(T[] inputs)
        {
            AllValues = new Heap<T>(inputs);
            AllValues.BuildHeap();
        }

        public PriorityQueue(List<T> inputs)
        {
            AllValues = new Heap<T>(inputs);
            AllValues.BuildHeap();
        }

        public void Enqueue(T elementToAdd)
        {
            AllValues.Add(elementToAdd);
        }

        public T Top()
        {
            return AllValues.Peek();
        }

        public T Dequeue()
        {
            return AllValues.Pop();
        }
    }

    public class Heap<T> where T : IComparable<T>
    {
        private List<T> AllValues;
        public int Count {
            get; private set; }

        public Heap(T[] inputs)
        {
            AllValues = new List<T>(inputs);
            Count = inputs.Count();
        }

        public Heap(List<T> inputs)
        {
            AllValues = new List<T>(inputs);
            Count = inputs.Count();
        }

        public void BuildHeap()
        {
            for (int i = Count / 2; i > 0; i--)
            {
                SiftDown(i - 1);
            }
        }

        public T Peek()
        {
            return AllValues[0];
        }

        public T Pop()
        {
            T topValue = AllValues[0];
            T bottomValue = AllValues[Count - 1];
            Swap(0, Count - 1);
            Count--;
            SiftDown(0);
            return topValue;
        }

        public void Add(T newElement)
        {
            AllValues.Insert(Count, newElement);
            SiftUp(Count);
            Count++;
        }

        public void SiftUp(int index)
        {
            if(index == 0)
            {
                return;
            }
            int bottomIndex = index;
            int topIndex = (bottomIndex + 1) / 2 - 1;
            if(CorrectWayRound(topIndex, bottomIndex))
            {
                return;
            }
            else
            {
                Swap(topIndex, bottomIndex);
                SiftUp(topIndex);
            }
        }

        //These shifts are in terms of the indices in the array and should compare 0 to 1 and 2
        public void SiftDown(int index)
        {
            int topIndex = index;
            int leftChildIndex = (topIndex + 1) * 2 - 1;
            int rightChildIndex = leftChildIndex + 1;

            //If there are no children
            if (topIndex + 1 > Count / 2)
            {
                return;
            }

            //If there is only one child
            if ((float)topIndex + 1 == (float)Count / 2)
            {
                if (CorrectWayRound(topIndex, leftChildIndex))
                {
                    return;
                }
                else
                {
                    Swap(topIndex, leftChildIndex);
                    return;
                }
            }

            //Should only run to here if there are three children
            //
            if (CorrectWayRound(topIndex, leftChildIndex) && CorrectWayRound(topIndex, rightChildIndex)) 
            {
                return;
            }
            else
            {
                if (CorrectWayRound(leftChildIndex, rightChildIndex))
                {
                    Swap(topIndex, leftChildIndex);
                    SiftDown(leftChildIndex);
                }
                else
                {
                    Swap(topIndex, rightChildIndex);
                    SiftDown(rightChildIndex);
                }
            }
        }

        private bool CorrectWayRound(int topIndex, int bottomIndex)
        {
            return AllValues[topIndex].CompareTo(AllValues[bottomIndex]) < 1;
        }

        private void Swap(int oneIndex, int otherIndex)
        {
            T temp = AllValues[oneIndex];
            AllValues[oneIndex] = AllValues[otherIndex];
            AllValues[otherIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Count + " elements: ");
            foreach (T item in AllValues)
            {
                sb.Append(" " + item.ToString());
            }
            return sb.ToString();
        }

    }
}
