using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class Node
    {
        public int data;
        public Node prev;
        public Node next;
        public Node(int _data, Node _prev, Node _next)
        {
            data = _data;
            prev = _prev;
            next = _next;
        }
    }
    class DoublyCircularLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public DoublyCircularLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Length()
        {
            return size;
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data, null, null);
            if (IsEmpty())
            {
                head = tail = newNode;
                head.data = data;
            }
            else
            {
                newNode.prev = head.prev;
                newNode.next = head;
                tail.next = newNode;
                head.prev = newNode;
                head = newNode;
            }
            size += 1;
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data, null, null);
            if (IsEmpty())
            {
                head = tail = newNode;
                head.data = data;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                newNode.next = head;
                head.prev = newNode;
                tail = newNode;
            }
            size += 1;
        }

        public void AddAny(int data, int position)
        {
            if (position <= 0 || position >= Length())
            {
                Console.WriteLine("Invalid position!");
                return;
            }
            else
            {
                Node newNode = new Node(data, null, null);
                int i = 1;
                Node temp = head;
                while (i < position - 1)
                {
                    temp = temp.next;
                    i++;
                }
                newNode.next = temp.next;
                newNode.prev = temp;
                temp.next.prev = newNode;
                temp.next = newNode;
                size += 1;
            }
        }

        public int DeleteFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked list is empty!");
                return -1;
            }
            else
            {
                int data;
                if (Length() == 1)
                {
                    data = head.data;
                    head = tail = null;
                    size -= 1;
                    return data;
                }
                else
                {
                    data = head.data;
                    tail.next = head.next;
                    head.next.prev = tail;
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
                if (Length() == 1)
                {
                    data = head.data;
                    head = tail = null;
                    size -= 1;
                    return data;
                }
                else
                {
                    data = tail.data;
                    tail.prev.next = head;
                    head.prev = tail.prev;
                    tail = tail.prev;
                    size -= 1;
                    return data;
                }
            }
        }

        public int DeleteAny(int position)
        {
            if(position <= 0 || position >= Length())
            {
                Console.WriteLine("Invalid position!");
                return -1;
            }
            else
            {
                int i = 1;
                Node temp = head;
                while(i < position)
                {
                    temp = temp.next;
                    i++;
                }
                int data = temp.data; 
                temp.next.prev = temp.prev;
                temp.prev.next = temp.next;
                size -= 1;
                return data;
            }
        }

        public void Display()
        {
            Node temp = head;
            int i = 0;
            while (i < Length())
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
                i++;
            }
        }

        static void Main(string[] args)
        {
            DoublyCircularLinkedList doublyLinkedList = new DoublyCircularLinkedList();
            doublyLinkedList.AddFirst(4);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.Display();
            Console.WriteLine();

            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.Display();
            Console.WriteLine();

            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.Display();
            Console.WriteLine();
            doublyLinkedList.AddAny(99, 2);
            doublyLinkedList.Display();
            Console.WriteLine();

            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.Display();
            Console.WriteLine();
            int DelF1 = doublyLinkedList.DeleteFirst();
            if (DelF1 != -1)
                Console.WriteLine("Deleted data: " + DelF1);
            doublyLinkedList.Display();
            Console.WriteLine();

            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.Display();
            Console.WriteLine();
            int DelL1 = doublyLinkedList.DeleteLast();
            if (DelL1 != -1)
                Console.WriteLine("Deleted data: " + DelL1);
            doublyLinkedList.Display();
            Console.WriteLine();

            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.Display();
            Console.WriteLine();
            int DelA1 = doublyLinkedList.DeleteAny(2);
            if (DelA1 != -1)
                Console.WriteLine("Deleted data: " + DelA1);
            doublyLinkedList.Display();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
