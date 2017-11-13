using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HeapWithGenerics;
using System.Text;

namespace UnitTestPriorityQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SiftDownTest()
        {
            List<SiftDownTester> siftDownTests = new List<SiftDownTester>();
            siftDownTests.Add(new SiftDownTester(new 
                List<int>(new int[] { 0, 1, 2 }),
                "3 elements:  0 1 2",
                0));
            siftDownTests.Add(new SiftDownTester(new
                List<int>(new int[] { 9, 1, 2 }),
                "3 elements:  1 9 2",
                0));

            siftDownTests.Add(new SiftDownTester(new
                List<int>(new int[] { 9, 2, 1 }),
                "3 elements:  1 2 9",
                0));

            siftDownTests.Add(new SiftDownTester(new
                List<int>(new int[] { 90, 20, 10 , 5}),
                "4 elements:  10 20 90 5",
                0));

            siftDownTests.Add(new SiftDownTester(new
                List<int>(new int[] { 90, 10, 20, 5 }),
                "4 elements:  10 5 20 90",
                0));

            foreach (ITestCase test in siftDownTests)
            {
                test.PerformTest();
            }
            
        }

        [TestMethod]
        public void BuildHeapTest()
        {
            List<BuildHeapTester> siftDownTests = new List<BuildHeapTester>();
            siftDownTests.Add(new BuildHeapTester(new
                List<int>(new int[] { 0, 1, 2 }),
                "3 elements:  0 1 2"));

            siftDownTests.Add(new BuildHeapTester(new
                List<int>(new int[] { 1, 9, 0 }),
                "3 elements:  0 9 1"));
                
            siftDownTests.Add(new BuildHeapTester(new
                List<int>(new int[] { 9, 1, 2 }),
                "3 elements:  1 9 2"));

            siftDownTests.Add(new BuildHeapTester(new
                List<int>(new int[] { 9, 2, 1 }),
                "3 elements:  1 2 9"));

            siftDownTests.Add(new BuildHeapTester(new
                List<int>(new int[] { 90, 20, 10, 5 }),
                "4 elements:  5 20 10 90"));

            siftDownTests.Add(new BuildHeapTester(new
                List<int>(new int[] { 90, 10, 20, 5 }),
                "4 elements:  5 10 20 90"));

            foreach (ITestCase test in siftDownTests)
            {
                test.PerformTest();
            }

        }

        [TestMethod]
        public void SiftUpTest()
        {
            List<SiftUpTester> siftUpTests = new List<SiftUpTester>();
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 3 }),
                "3 elements:  1 3 3",
                0));
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 3 }),
                "3 elements:  1 3 3",
                2));
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 0 }),
                "3 elements:  0 3 1",
                2));
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 3, 7, 7, 7, 7, 15, 15, 15, 15, 15, 15, 15, 15 }),
                "15 elements:  1 3 3 7 7 7 7 15 15 15 15 15 15 15 15",
                14));
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 3, 7, 7, 7, 7, 15, 15, 15, 15, 15, 15, 15, 5 }),
                "15 elements:  1 3 3 7 7 7 5 15 15 15 15 15 15 15 7",
                14));
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 3, 7, 7, 7, 7, 15, 15, 15, 15, 15, 15, 2 }),
                "14 elements:  1 3 2 7 7 7 3 15 15 15 15 15 15 7",
                13));
            siftUpTests.Add(new SiftUpTester(new
                List<int>(new int[] { 1, 3, 3, 7, 7, 7, 7, 0}),
                "8 elements:  0 1 3 3 7 7 7 7",
                7));
            foreach (ITestCase test in siftUpTests)
            {
                test.PerformTest();
            }
        }

        [TestMethod]
        public void AddTest()
        {
            List<AddTester> addTests = new List<AddTester>();
            addTests.Add(new AddTester(
                new List<int>(),
                "1 elements:  -9",
                -9));
            addTests.Add(new AddTester(new
                List<int>(new int[] { 1, 3, 3 }),
                "4 elements:  1 3 3 3",
                3));
            addTests.Add(new AddTester(new
                List<int>(new int[] { 1, 3, 3 }),
                "4 elements:  1 2 3 3",
                2));
            addTests.Add(new AddTester(new
                List<int>(new int[] { 1, 3, 3, 7 }),
                "5 elements:  1 2 3 7 3",
                2));
            addTests.Add(new AddTester(new
                List<int>(new int[] { 1, 3, 3, 7 ,7}),
                "6 elements:  0 3 1 7 7 3",
                0));
            foreach (ITestCase test in addTests)
            {
                test.PerformTest();
            }
        }

        [TestMethod]
        public void PopTestInt()
        {
            slowPriorityQueue<int> slowQueue = new slowPriorityQueue<int>( new List<int>());
            Heap<int> fastQueue = new Heap<int>(new List<int>());
            Random Randomiser = new Random();



            List<int> inputs = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                int nextNeg = Randomiser.Next(-99, 0);
                int nextPos = Randomiser.Next(1, 99);
                inputs.Add(nextNeg);
                inputs.Add(nextPos);
            }

            foreach (int item in inputs)
            {
                fastQueue.Add(item);
                slowQueue.Add(item);
            }
            StringBuilder sbExpected = new StringBuilder();
            StringBuilder sbActual = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                sbExpected.Append(slowQueue.Pop() + " ");
                sbActual.Append(fastQueue.Pop() + " ");
            }
            Assert.AreEqual(sbExpected.ToString(), sbActual.ToString());

            for (int i = 0; i < 20; i++)
            {
                int nextNeg = Randomiser.Next(-99, 0);
                int nextPos = Randomiser.Next(1, 99);
                inputs.Add(nextNeg);
                inputs.Add(nextPos);
            }

            while(slowQueue.Count != 0)
            {
                sbExpected.Append(slowQueue.Pop() + " ");
                sbActual.Append(fastQueue.Pop() + " ");
            }
            Assert.AreEqual(sbExpected.ToString(), sbActual.ToString());
        }

        [TestMethod]
        public void PopTestLong()
        {
            slowPriorityQueue<long> slowQueue = new slowPriorityQueue<long>(new List<long>());
            Heap<long> fastQueue = new Heap<long>(new List<long>());
            Random Randomiser = new Random();

            List<int> inputs = new List<int>();
            for (int i = 0; i < 19; i++)
            {
                int nextNeg = Randomiser.Next(-99, 0);
                int nextPos = Randomiser.Next(1, 99);
                inputs.Add(nextNeg);
                inputs.Add(nextPos);
            }

            foreach (int item in inputs)
            {
                fastQueue.Add(item);
                slowQueue.Add(item);
            }
            StringBuilder sbExpected = new StringBuilder();
            StringBuilder sbActual = new StringBuilder();
            for (int i = 0; i < 17; i++)
            {
                sbExpected.Append(slowQueue.Pop() + " ");
                sbActual.Append(fastQueue.Pop() + " ");
            }
            Assert.AreEqual(sbExpected.ToString(), sbActual.ToString());

            for (int i = 0; i < 20; i++)
            {
                int nextNeg = Randomiser.Next(-99, 0);
                int nextPos = Randomiser.Next(1, 99);
                inputs.Add(nextNeg);
                inputs.Add(nextPos);
            }

            while (slowQueue.Count != 0)
            {
                sbExpected.Append(slowQueue.Pop() + " ");
                sbActual.Append(fastQueue.Pop() + " ");
            }
            Assert.AreEqual(sbExpected.ToString(), sbActual.ToString());
        }

        [TestMethod]
        public void QueueTest()
        {
            PriorityQueue<int> myQueue = new PriorityQueue<int>();
            slowPriorityQueue<int> slowQueue = new slowPriorityQueue<int>(new List<int>());
            Random Randomiser = new Random();

            StringBuilder sbExpected = new StringBuilder();
            StringBuilder sbActual = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                int nextNeg = Randomiser.Next(1, 1000);
                int nextPos = Randomiser.Next(1001, 10000);
                int nextBig = Randomiser.Next(10001, 100000);

                myQueue.Enqueue(nextNeg);
                slowQueue.Add(nextNeg);
                myQueue.Enqueue(nextPos);
                slowQueue.Add(nextPos);
                myQueue.Enqueue(nextBig);
                slowQueue.Add(nextBig);
                
                sbExpected.Append(slowQueue.Pop() + " ");
                sbActual.Append(myQueue.Dequeue() + " ");
                
            }

            while(myQueue.Count != 0)
            {
                sbActual.Append(myQueue.Dequeue() + " ");
                sbExpected.Append(slowQueue.Pop() + " ");
            }
            Assert.AreEqual(sbExpected.ToString(), sbActual.ToString());
        }
    }

    public class slowPriorityQueue<T> where T : IComparable<T>
    {
        public int Count {get { return AllValues.Count; } }

        private List<T> AllValues;

        public slowPriorityQueue(List<T> inputs)
        {
            AllValues = inputs;
        }

        public void Add(T anotherElement)
        {
            AllValues.Add(anotherElement);
        }

        public T Pop()
        {
            AllValues.Sort();
            T topValue = AllValues[0];
            AllValues.RemoveAt(0);
            return topValue;
        }
    }

    public abstract class ITestCase
    {
        protected Heap<int> priorityQueue;
        List<int> input;
        public String Expected { get; }
        protected String Output;

        public ITestCase(List<int> input, String Expected)
        {
            this.input = input;
            this.Expected = Expected;
            priorityQueue = new Heap<int>(input);
        }

        public void PerformTest()
        {
            RuntimeMethodUnderTest();
            Assert.AreEqual(this.Expected, this.GetOutput());
        }

        private String GetOutput()
        {
            return priorityQueue.ToString();
        }

        protected abstract void RuntimeMethodUnderTest();
    }

    public class AddTester : ITestCase
    {
        private int toAdd;

        public AddTester(List<int> input, String Expected, int toAdd) : base(input, Expected)
        {
            this.toAdd = toAdd;
        }

        protected override void RuntimeMethodUnderTest()
        {
            priorityQueue.Add(toAdd);
        }
    }

    public class SiftUpTester : ITestCase
    {
        int index;

        public SiftUpTester(List<int> input, String Expected, int index) : base(input, Expected)
        {
            this.index = index;
        }

        protected override void RuntimeMethodUnderTest()
        {
            priorityQueue.SiftUp(index);
        }
    }

    public class BuildHeapTester : ITestCase
    {
        public BuildHeapTester(List<int> input, String Expected) : base(input, Expected) { }

        protected override void RuntimeMethodUnderTest()
        {
            priorityQueue.BuildHeap();
        }
    }

    public class SiftDownTester : ITestCase
    {
        int position;

        public SiftDownTester(List<int> input, String Expected, int position):base(input, Expected)
        {
            this.position = position;
        }

        protected override void RuntimeMethodUnderTest()
        {
            priorityQueue.SiftDown(position);
            Output = priorityQueue.ToString();
        }
    }
}
