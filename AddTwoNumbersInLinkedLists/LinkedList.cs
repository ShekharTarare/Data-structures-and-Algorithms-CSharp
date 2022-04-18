using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbersInLinkedLists
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

    /// <summary>
    /// time complexity: O(max(n,m))
    /// Space complexity: O(max(n,m))
    /// </summary>
    public static class AddTwoNumbers
    {
        public static Node AddTwoNumbersInLinkedLists(Node list1, Node list2)
        {
            if (list1 == null || list2 == null)
                return null;

            Node tempNode = new Node(0); //new linkedlist
            Node currNode = tempNode;
            int carry = 0, sum = 0;
            while (list1 != null || list2 != null)
            {
                int x, y;
                x = list1 == null ? 0: list1.data;
                y = list2 == null ? 0 : list2.data;

                sum = x + y + carry;
                currNode.next = new Node(sum % 10);
                currNode = currNode.next;
                carry = sum / 10;
                if (list1 != null)
                    list1 = list1.next;
                if (list2 != null)
                    list2 = list2.next;
            }
            if (carry > 0)
                currNode.next = new Node(carry);

            return tempNode.next;
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

        public void Display(Node temp)
        {
            while (temp != null)
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
            linkedList1.AddToTail(2);
            linkedList1.AddToTail(4);
            linkedList1.AddToTail(3);

            LinkedList linkedList2 = new LinkedList();
            linkedList2.AddToTail(5);
            linkedList2.AddToTail(6);
            linkedList2.AddToTail(4);

            Node res = AddTwoNumbers.AddTwoNumbersInLinkedLists(linkedList1.head, linkedList2.head);
            if (res == null)
                Console.WriteLine("LinkedLists are empty!");
            else
                linkedList1.Display(res);
            Console.ReadKey();
        }
    }
}
