using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleDetectionLinkedListUsingHashSet
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
            int i = 0;
            while (temp != null && i != size)
            {
                Console.Write(temp.data + " ");
                i++;
                temp = temp.next;
            }
            Console.WriteLine();
        }

        //Time: O(n)
        //Space: O(n) as we are using hashset to store the nodes of the linked list
        public void AddToTail(int data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
                head = newNode;
            else
                tail.next = newNode;
            tail = newNode;
            size += 1;
        }

        public bool CycleDetection()
        {
            HashSet<Node> nodes = new HashSet<Node>();
            Node temp = head;

            while(temp != null)
            {
                if (nodes.Contains(temp))
                    return true;
                nodes.Add(temp);
                temp = temp.next;
            }
            return false;
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
            if (linkedList.CycleDetection())
                Console.WriteLine("Cycle detected!");
            else
                Console.WriteLine("Cycle not detected!");
            Console.ReadKey();
        }
    }
}
