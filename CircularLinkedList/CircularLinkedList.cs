using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int _data, Node _next)
        {
            data = _data;
            next = _next;
        }
    }
    class CircularLinkedList
    {
        private Node head;
        private Node tail;
        private int size;
        public CircularLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int Length()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data, null);
            if (IsEmpty())
            {
                newNode.next = newNode;
                head = newNode;
            }
            else
            {
                newNode.next = tail.next;
                tail.next = newNode;
            }
            tail = newNode;
            size += 1;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data, null);
            if (IsEmpty())
            {
                newNode.next = newNode;
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.next = head;
                head = newNode;
            }
            size += 1;
        }

        public void AddAny(int data, int position)
        {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid position!");
                return;
            }
            else
            {
                Node newNode = new Node(data, null);
                int i = 1;
                Node temp = head;
                while (i < position - 1)
                {
                    temp = temp.next;
                    i++;
                }
                newNode.next = temp.next;
                temp.next = newNode;
                size += 1;
            }
        }

        public int DeleteFirst()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Linked list is empty!");
                return -1;
            }
            else
            {
                int data;
                if(size == 1)
                {
                    data = head.data;
                    head = tail = null;
                    size -= 1;
                    return data;
                }
                else
                {
                    tail.next = head.next;
                    data = head.data;
                    head = head.next;
                    size -= 1;
                    return data;
                }
            }
        }

        public int DeleteLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked list is empty!");
                return -1;
            }
            else
            {
                int data;
                if (size == 1)
                {
                    data = head.data;
                    head = tail = null;
                    size -= 1;
                    return data;
                }
                else
                {
                    Node p = head;
                    int i = 1;
                    while(i < Length() - 1)
                    {
                        p = p.next;
                        i++;
                    }
                    tail = p;
                    p = p.next;
                    tail.next = head;
                    data = p.data;
                    size -= 1;
                    return data;
                }
            }
        }

        public int DeleteAny(int position)
        {
            if(position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid position!");
                return -1;
            }
            else
            {
                int data;
                int i = 1;
                Node p = head;
                while(i < position - 1)
                {
                    p = p.next;
                    i++;
                }
                data = p.next.data;
                p.next = p.next.next;
                size -= 1;
                return data;
            }
        }

        public void Display()
        {
            int i = 0;
            Node temp = head;
            while (i < Length())
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
                i++;
            }
        }

        static void Main(string[] args)
        {
            CircularLinkedList circularLinkedList = new CircularLinkedList();
            circularLinkedList.AddLast(4);
            circularLinkedList.AddLast(3);
            circularLinkedList.AddLast(2);
            circularLinkedList.Display();
            Console.WriteLine();

            circularLinkedList.AddFirst(4);
            circularLinkedList.AddFirst(3);
            circularLinkedList.AddFirst(2);
            circularLinkedList.Display();
            Console.WriteLine();

            circularLinkedList.AddFirst(4);
            circularLinkedList.AddFirst(3);
            circularLinkedList.AddFirst(2);
            circularLinkedList.Display();
            Console.WriteLine();
            Console.WriteLine(circularLinkedList.size);
            circularLinkedList.AddAny(99, 2);
            circularLinkedList.Display();
            Console.WriteLine();

            int deleteF1 = circularLinkedList.DeleteFirst();
            if (deleteF1 != -1)
                Console.WriteLine("Deleted data: " + deleteF1);
            circularLinkedList.Display();
            Console.WriteLine();

            int deleteL1 = circularLinkedList.DeleteLast();
            if (deleteL1 != -1)
                Console.WriteLine("Deleted data: " + deleteL1);
            circularLinkedList.Display();
            Console.WriteLine();

            int deleteA1 = circularLinkedList.DeleteAny(3);
            if (deleteA1 != -1)
                Console.WriteLine("Deleted data: " + deleteA1);
            circularLinkedList.Display();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
