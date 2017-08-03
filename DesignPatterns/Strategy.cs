using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

// This example shows Template method in addtion to Strategy pattern

namespace DesignPatterns.Behavioral
{
    public class Sort
    {
        private ASort algorithm;

        public Sort(ASort a)
        {
            algorithm = a;
        }

        public void Run(int[] a, bool print = false)
        {
            algorithm.Sort(a);

            if (print)
            {
                Console.WriteLine(String.Format("Algorithm: {0} {2} \nElapsed Time: {1}",
                    algorithm.Name, algorithm.Elapsed, algorithm.Order));
                
                Print(a);
                Console.WriteLine(new String('=', 50));
            }
        }

        private void Print(int[] a)
        {
            int size = a.Length;
            for (int i = 0; i < size; ++i)
            {
                if (i % 10 == 0)
                    Console.WriteLine();
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }

    public abstract class ASort
    {      
        public ASort(String name)
        {
            sw = new Stopwatch();
            Order = Type.ASC;
            this.Name = name;
        }

        public String Name
        {
            private set;
            get;
        }

        public TimeSpan Elapsed
        {
            private set
            {
                this.Elapsed = value;
            }
            get
            {
                return sw.Elapsed;
            }
        }

        public Type Order
        {
            set;
            get;
        }

        public enum Type { ASC, DESC };

        public void Sort(int[] a)
        {
            try
            {
                sw.Start();
                Algorithm(a, Order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);// throw e;
            }
            finally
            {
                sw.Stop();
            }
        }

        protected void Swap(int[] a, int indexX, int indexY)
        {
            int temp = a[indexX];
            a[indexX] = a[indexY];
            a[indexY] = temp;
        }

        protected abstract void Algorithm(int[] a, Type order);
        private Stopwatch sw;
    }

    public class MergeSort : ASort
    {
        public MergeSort() : base("MergeSort") { }
        protected override void Algorithm(int[] a, Type order)
        {
            mergeSort(a, 0, a.Length - 1);
        }

        private void mergeSort(int[] a, int start, int end)
        {
            if (start < end)
            {
                // Same as (l+r)/2, avoids overflow for large l and h
                int mid = (end + start) / 2;//start + (end - start) / 2;

                // Sort first and second halves
                mergeSort(a, start, mid);
                mergeSort(a, mid + 1, end);

                merge(a, start, mid, end);
            }
        }

        private void merge(int[] a, int start, int mid, int end)
        {
            // create temp arrays 
            int[] L = Copy(a, start, mid);
            int[] R = Copy(a, mid + 1, end);

            // Merge the temp arrays back into arr[l..r]
            int i = 0; // Initial index of first subarray
            int j = 0; // Initial index of second subarray

            for (int k = start; k < end; ++k)
            {
                if ((i < L.Length && j < R.Length) && L[i] <= R[j])
                    a[k] = L[i++];
                else if (j < R.Length)
                    a[k] = R[j++];
            }
        }

        private int[] Copy(int[]a, int start, int end)
        {
            int[] temp = new int[end - start + 1];
            int k = 0;
            for(int i = start; i<=end; ++i)
            {
                temp[k++] = a[i];
            }
            return temp;
        }
    }

    public class InsertionSort : ASort
    {
        public InsertionSort() : base("InsertionSort") { }
        protected override void Algorithm(int[] a, Type order)
        {
            int size = a.Length;
            for (int i = 1; i < size; ++i)
            {
                for (int k = i; k > 0; --k)
                {
                    int first = k - 1;
                    int second = k;
                    bool firstGreater = (a[first] > a[second]) ? true : false;
                    switch(order)
                    {
                        case Type.ASC:
                            if (firstGreater)
                                Swap(a, first, second);
                            break;
                        case Type.DESC:
                            if (!firstGreater)
                                Swap(a, second, first);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    public class BubbleSort : ASort
    {
        public BubbleSort() : base("BubbleSort") { }
        protected override void Algorithm(int[] a, Type order)
        {
            int size = a.Length;
            for(int i=0; i<size; ++i)
            {
                for (int k=0; k<size - 1; ++k)
                {
                    int first = k;
                    int second = k+1;
                    bool firstGreater = (a[first] > a[second]) ? true : false;
                    switch(order)
                    {
                        case Type.ASC:
                            if (firstGreater)
                                Swap(a, first, second);
                            break;
                        case Type.DESC:
                            if (!firstGreater)
                                Swap(a, second, first);
                            break;
                        default:
                            break;   
                    }

                }
            }
        }
    }
}
