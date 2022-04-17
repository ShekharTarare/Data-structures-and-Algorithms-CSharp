using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_DesignSinglyLinkedList
{
    public class MyLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public MyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;
            else
            {
                int i = 0;
                Node temp = head;
                while (i < index)
                {
                    temp = temp.next;
                    i++;
                }
                return temp.data;
            }
        }

        public void AddAtHead(int val)
        {
            Node newNode = new Node(val);
            if (size == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
            size += 1;
        }

        public void AddAtTail(int val)
        {
            Node newNode = new Node(val);
            if (size == 0)
            {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
            size += 1;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > size || index < 0)
                return;
            Node newNode = new Node(val);
            if (index == 0)
                AddAtHead(val);
            else if (index == size)
                AddAtTail(val);
            else
            {
                Node temp = head;
                int i = 0;
                while (i < index - 1)
                {
                    temp = temp.next;
                    i++;
                }
                newNode.next = temp.next;
                temp.next = newNode;
                size += 1;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= size || index < 0)
                return;
            if (size == 1)
            {
                head = tail = null;
            }
            else
            {
                if (index == 0)
                {
                    head = head.next;
                }
                else
                {
                    Node temp = head;
                    int i = 0;
                    while (i < index - 1)
                    {
                        temp = temp.next;
                        i++;
                    }
                    if (index == size - 1)
                    {
                        temp.next = null;
                        tail = temp;
                    }
                    else
                    {
                        temp.next = temp.next.next;
                    }
                }
            }
            size -= 1;
        }

        public void Display()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.AddAtHead(2);
            myLinkedList.Display();
            myLinkedList.DeleteAtIndex(1);
            myLinkedList.Display();
            myLinkedList.AddAtHead(2);
            myLinkedList.Display();
            myLinkedList.AddAtHead(7);
            myLinkedList.Display();
            myLinkedList.AddAtHead(3);
            myLinkedList.Display();
            myLinkedList.AddAtHead(2);
            myLinkedList.Display();
            myLinkedList.AddAtHead(5);
            myLinkedList.Display();
            myLinkedList.AddAtTail(5);
            myLinkedList.Display();
            myLinkedList.DeleteAtIndex(5);
            myLinkedList.Display();
            Console.ReadKey();
        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int _data)
        {
            data = _data;
            next = null;
        }
    }
}
