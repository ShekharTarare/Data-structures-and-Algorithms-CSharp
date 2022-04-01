using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturnNodeIfCyclePresent
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
        private int size;
        private Node head;
        private Node tail;
        public LinkedList()
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

        public void Display()
        {
            Node temp = head;
            int count = 0;
            while (temp != null && count != size)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
                count++;
            }
            Console.WriteLine();
        }

        public void AddToTail(int data)
        {
            Node newNode = new Node(data);
            if(IsEmpty())
            {
                head = newNode;
            }
            else
            {
                tail.next = newNode;
            }
            tail = newNode;
            size += 1;
        }

        //Return the node where the cycle begins. If there is no cycle, return null.
        //Time: O(n), 
        //Space: O(1)
        public Node ReturnNodeIfCycleDetected()
        {
            if (head == null)
                return null;

            Node slower = head;
            Node faster = head;
            while(faster != null && faster.next != null)
            {
                slower = slower.next;
                faster = faster.next.next;
                if (slower == faster)
                    break;
            }

            if (faster == null || faster.next == null) return null;

            slower = head;
            while(slower != faster)
            {
                slower = slower.next;
                faster = faster.next;
            }
            return faster;
        }

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTail(1);
            linkedList.AddToTail(2);
            linkedList.AddToTail(3);
            linkedList.Display();
            linkedList.tail.next = linkedList.head.next;
            linkedList.Display();
            Node res = linkedList.ReturnNodeIfCycleDetected();
            if (res == null)
                Console.WriteLine("No cycle detected!");
            else
                Console.WriteLine("Cycle detected on Node having data: " + res.data);
            Console.ReadKey();
        }
    }
}
