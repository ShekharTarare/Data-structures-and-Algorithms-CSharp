using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_DesignSinglyLinkedList
{
    public class MyLinkedList
    {
        private Node head, tail;
        private int size;
        public MyLinkedList()
        {
            head = tail = null;
            size = 0;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
                return -1;
            Node temp = head;
            int i = 0;
            while (i < index)
            {
                temp = temp.next;
                i++;
            }
            return temp.data;
        }

        public void AddAtHead(int val)
        {
            Node newNode = new Node(val);
            if (size == 0)
                head = tail = newNode;
            else
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            size++;
        }

        public void AddAtTail(int val)
        {
            Node newNode = new Node(val);
            if (size == 0)
                head = tail = newNode;
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            size++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > size || index < 0)
                return;
            else if (index == size)
                AddAtTail(val);
            else if (index == 0)
                AddAtHead(val);
            else
            {
                Node newNode = new Node(val);
                int i = 0;
                Node temp = head;
                while (i < index - 1)
                {
                    temp = temp.next;
                    i++;
                }
                newNode.prev = temp;
                newNode.next = temp.next;
                newNode.next.prev = newNode;
                temp.next = newNode;
                size++;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= size || index < 0)
                return;
            else if (index == 0)
            {
                if (size == 1)
                    head = tail = null;
                else
                {
                    head = head.next;
                    head.prev = null;
                }
            }
            else if (index == size - 1)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                int i = 0;
                Node temp = head;
                while (i < index)
                {
                    temp = temp.next;
                    i++;
                }
                temp.prev.next = temp.next;
                temp.next.prev = temp.prev;
            }
            size--;
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
        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node prev;
        public Node(int _data)
        {
            prev = next = null;
            data = _data;
        }
    }
}
