using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenLinkedList
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
        private Node head, tail;
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
            if (IsEmpty())
                head = newNode;
            else
                tail.next = newNode;
            tail = newNode;
            size += 1;
        }

        //Time: O(n)
        //Space: O(1)
        public void OddEvenSolution()
        {
            if (IsEmpty())
                return;
            Node odd = head; //for traversing the odd index nodes
            Node even = head.next; //for traversing the even index nodes
            Node evenHead = even; //This will act as the head of the even linkedlist

            while(even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;                
                even = even.next;
            }
            odd.next = evenHead;
        }

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);
            linkedList.AddLast(6);
            linkedList.AddLast(7);
            linkedList.AddLast(8);
            linkedList.Display();
            linkedList.OddEvenSolution();
            linkedList.Display();
            Console.ReadKey();
        }
    }
}
