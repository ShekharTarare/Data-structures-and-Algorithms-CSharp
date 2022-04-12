using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseTheLinkedList
{
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
    class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;
        public LinkedList()
        {
            head = tail = null;
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

        public void Display()
        {
            Node temp = head;
            while(temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        public void AddLast(int data)
        {
            Node newNode = new Node(data);
            if(IsEmpty())
                head = newNode;
            else
                tail.next = newNode;
            tail = newNode;
            size += 1;
        }

        //1) next should point to next node of curr
        //2) current should point to prev
        //3) prev should point to curr and curr should point to next
        public void ReverseLinkedList()
        {
            Node prev = null;
            Node next;
            Node curr = head;
            while(curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddLast(5);
            linkedList.AddLast(4);
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            linkedList.AddLast(1);
            linkedList.Display();
            linkedList.ReverseLinkedList();
            linkedList.Display();
            Console.ReadKey();
        }
    }
}
