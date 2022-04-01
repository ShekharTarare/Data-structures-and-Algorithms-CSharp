using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydCycleDetectionInLinkedList
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
        
        public void AddToTail(int data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
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

        //Two pointer approach (Floyd's Cycle Detection Algorithm): One pointer will move slowly (One location) and other will
        //move fastly (Two location). If there is a loop then they will meet if not then they won't
        //Time - O(N) N is the number of nodes in the linked list,
        //Space - O(1) as we are using two pointers
        public bool CycleDetection()
        {
            if (head == null)
                return false;

            Node slow = head;
            Node fast = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }

        public void Display()
        {
            Node temp = head;
            int count = 0;
            while(temp != null && count != size)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
                count++;
            }
            Console.WriteLine();
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
