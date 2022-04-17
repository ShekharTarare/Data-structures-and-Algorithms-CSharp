using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedLinkedList
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
    /// time complexity: O(n)
    /// Space complexity: O(1)
    /// Below, we are modifying the list1.
    /// </summary>
    public static class MergeLinkedList
    {
        public static Node MergeTwoLists(Node list1, Node list2)
        {
            if (list1 == null && list2 != null)
                return list2;
            else if (list2 == null && list1 != null)
                return list1;
            else if (list1 == null && list2 == null)
                return null;
                
            Node tempFirst = list1, tempSecond, follower = null;
            while (tempFirst != null && list2 != null)
            {
                if (tempFirst.data >= list2.data)
                {
                    tempSecond = list2;
                    if (follower == null)
                    {
                        list2 = list2.next;
                        tempSecond.next = list1;
                        list1 = tempSecond;
                    }
                    else
                    {
                        list2 = list2.next;
                        tempSecond.next = follower.next;
                        follower.next = tempSecond;
                    }
                    follower = tempSecond;
                }
                else
                {
                    follower = tempFirst;
                    tempFirst = tempFirst.next;
                }
            }
            if (list2 != null)
                follower.next = list2;
            
            return list1;
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
            linkedList1.AddToTail(1);
            linkedList1.AddToTail(2);
            linkedList1.AddToTail(4);

            LinkedList linkedList2 = new LinkedList();
            linkedList2.AddToTail(1);
            linkedList2.AddToTail(3);
            linkedList2.AddToTail(4);

            Node res = MergeLinkedList.MergeTwoLists(linkedList1.head, linkedList2.head);
            if (res == null)
                Console.WriteLine("LinkedLists are empty!");
            else
                linkedList1.Display(res);
            Console.ReadKey();
        }
    }
}
