using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfTwoLinkedList
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

    //Time: O(m+n)
    //Space: O(1)
    public static class GetIntersection
    {
        public static Node GetIntersectionNode(Node A, Node B)
        {
            if (A == null || B == null)
                return null;
            //A: head of A
            //B: head of B
            //headA: temporary Node for A
            //headB: temporary Node for B
            Node headA = A;
            Node headB = B;

            while (headA != headB)
            {
                headA = headA == null ? headA = B : headA.next;
                headB = headB == null ? headB = A : headB.next;
            }
            return headA;
        }
    }

    class LinkedList
    {
        private Node head, tail;
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

        static void Main(string[] args)
        {
            LinkedList linkedList1 = new LinkedList();
            linkedList1.AddToTail(4);
            linkedList1.AddToTail(1);
            linkedList1.AddToTail(8);
            linkedList1.AddToTail(4);
            linkedList1.AddToTail(5);

            LinkedList linkedList2 = new LinkedList();
            linkedList2.AddToTail(5);
            linkedList2.AddToTail(6);
            linkedList2.AddToTail(1);
            linkedList2.tail.next = linkedList1.head.next.next;

            Console.Write("LinkedList A -> ");
            linkedList1.Display();

            Console.Write("LinkedList B -> ");
            linkedList2.Display();

            Node res = GetIntersection.GetIntersectionNode(linkedList1.head, linkedList2.head);
            if (res != null)
                Console.WriteLine("Intersection at " + res.data);
            else
                Console.WriteLine("No intersection");
            Console.ReadKey();
        }
    }
}
