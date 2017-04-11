using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eristiq_test_1
{
    class Program
    {
        class MyLinkedList<T>
        {
            private T[] arr;
            private T[] arrRever;
            public int CountList { get; set; }
            public int LengthList { get; set; }

            public MyLinkedList(T[] arr)
            {
                this.arr = arr;
                CountList = arr.Length;
                LengthList = arr.Length;
            }

            public T[] ReverseList()
            {
                arrRever = new T[CountList];
                for (int i = CountList, j = 0; i-- != 0;)
                {
                    arrRever[j++] = arr[i];
                }
                return arrRever;
            }

            public T ElementAt(int n)
            {
                return arr[n];
            }

            public T First
            {
                get
                {
                    return arr[0];
                }
            }

            public T Last
            {
                get
                {
                    return arr[arr.Length - 1];
                }
            }

            public T GetBefore(int index)
            {
                return arr[index - 1];
            }

            public T GetAfter(int index)
            {
                return arr[index + 1];
            }

            public void AddBefore(int index, T value)
            {
                bool f = false;

                Array.Resize(ref arr, arr.Length + 1);
                CountList++;
                LengthList++;

                T[] arrSecond = new T[arr.Length + 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (index - 1 == i)
                    {
                        f = true;
                        arrSecond[i] = value;
                    }

                    if (f)
                    {
                        arrSecond[i + 1] = arr[i];
                    }
                    else
                    {
                        arrSecond[i] = arr[i];
                    }
                }
                arr = arrSecond;
            }

            public void AddAfter(int index, T value)
            {
                bool f = false;

                Array.Resize(ref arr, arr.Length + 1);
                CountList++;
                LengthList++;

                T[] arrSecond = new T[arr.Length + 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (index + 1 == i)
                    {
                        f = true;
                        arrSecond[i] = value;
                    }

                    if (f)
                    {
                        arrSecond[i + 1] = arr[i];
                    }
                    else
                    {
                        arrSecond[i] = arr[i];
                    }
                }
                arr = arrSecond;
            }
        }

        static void Main(string[] args)
        {

            MyLinkedList<int> list = new MyLinkedList<int>(new int[] { 1, 3, 50, 30, 100, 70 });

            for (int i = 0; i < list.LengthList; i++)
            {
                Console.WriteLine(list.ElementAt(i));
            }


            list.AddAfter(2, 888);
            list.AddBefore(4, 999);

            Console.WriteLine();
            for (int i = 0; i < list.LengthList; i++)
            {
                Console.WriteLine(list.ElementAt(i));
            }


            var revList = list.ReverseList();

            Console.WriteLine();
            for (int i = 0; i < list.LengthList; i++)
            {
                Console.WriteLine(list.ElementAt(i));
            }


        }
    }
}
