using System;
using System.Collections;
using System.Collections.Generic;

namespace Eristiq_test_1
{
    public class Node
    {
        private object _Data;
        private Node _Next;
        private Node _Prev;
        public object Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public Node(object Data)
        {
            this._Data = Data;
        }
        public Node Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
        public Node Prev
        {
            get { return this._Prev; }
            set { this._Prev = value; }
        }
    }

    class Doubly_Linked_List
    {
        private Node First;
        private Node Current;
        private Node Last;
        private uint size;

        public Doubly_Linked_List()
        {
            size = 0;
            First = Current = Last = null;
        }

        public bool isEmpty //проверка на пустоту
        {
            get
            {
                return size == 0;
            }
        }

        public void Insert_Index(object newElement, uint index) //вставить по индекусу
        {
            if (index < 1 || index > size) //вброс ошибки, если неправильный индекс
            {
                throw new InvalidOperationException();
            }
            else if (index == 1) //если начало
            {
                Push_Front(newElement);
            }
            else if (index == size) //если конец
            {
                Push_Back(newElement);
            }
            else //иначе ищем элемент с таким индексом
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Node newNode = new Node(newElement); //создаем объект
                Current.Prev.Next = newNode;
                newNode.Prev = Current.Prev;
                Current.Prev = newNode;
                newNode.Next = Current;
            }
        }

        public void Push_Front(object newElement)
        {
            Node newNode = new Node(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode; //First и newNode указывают на один и тот же объект
                newNode.Next.Prev = First;
            }
            Count++;
        }

        public Node Pop_Front()
        {
            if (First == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
                return temp;
            }
        }

        public void Push_Back(object newElement)
        {
            Node newNode = new Node(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            Count++;
        }

        public Node Pop_Back()
        {
            if (Last == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                Count--;
                return temp;
            }
        }

        public void ClearList() //полностью очистить список
        {
            while (!isEmpty)
            {
                Pop_Front();
            }
        }

        public uint Count //свойство для size
        {
            get { return size; }
            set { size = value; }
        }

        public void Display() //вывести в прямом порядке
        {
            if (First == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Current = First;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Element " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Next;
            }
        }

        public void ReverseDisplay() //вывести в обратном порядке
        {
            if (Last == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Current = Last;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Element " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Prev;
            }
        }

        public void DeleteElement(uint index)
        { //удалить элемент по индексу
            if (index < 1 || index > size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 1)
            {
                Pop_Front();
            }
            else if (index == size)
            {
                Pop_Back();
            }
            else
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Current.Prev.Next = Current.Next;
                Current.Next.Prev = Current.Prev;
            }
        }

        public Node FindNode(object Data) //найти Node и вернуть его
        {
            Current = First;
            while (Current != null)
            {
                Current = Current.Next;
            }
            return Current;
        }

        public uint GetIndex(object Data) //достать индекс по значению элемента
        {
            Current = First;
            uint index = 1;
            while (Current != null)
            {
                Current = Current.Next;
                index++;
            }
            return index;

        }

    }


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

            //MyLinkedList<int> list = new MyLinkedList<int>(new int[] { 1, 3, 50, 30, 100, 70 });

            //for (int i = 0; i < list.LengthList; i++)
            //{
            //    Console.WriteLine(list.ElementAt(i));
            //}


            //list.AddAfter(2, 888);
            //list.AddBefore(4, 999);

            //Console.WriteLine();
            //for (int i = 0; i < list.LengthList; i++)
            //{
            //    Console.WriteLine(list.ElementAt(i));
            //}


            //var revList = list.ReverseList();

            //Console.WriteLine();
            //for (int i = 0; i < revList.Length; i++)
            //{
            //    Console.WriteLine(revList[i]);
            //}


            Doubly_Linked_List l = new Doubly_Linked_List();
            l.Push_Front(1);
            l.Push_Front(2);
            l.Push_Front(3);
            l.Push_Front(4);

            l.ReverseDisplay();
            l.Display();

            

        }
    }
}
