using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNthNodeFromEndOfList
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
        private Node head, tail;
        public LinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int Length()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
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

        //using one pointer 
        //Time: O(n)
        //Space: O(1)
        //num will be in between 1 to the size
        public int RemoveFromLast(int num)
        {
            if (num <= 0 || num > size)
                return -1;
            else
            {
                int data;
                if (IsEmpty())
                    return -1;
                else if(size == 1 && num == 1)
                {
                    data = head.data;
                    size -= 1;
                    return data;
                }
                else
                {
                    Node temp = head;
                    int i = 1;
                    if (size - num == 0)
                    {
                        data = head.data;
                        head = head.next;
                        size -= 1;
                        return data;
                    }
                    while (i < size - num)
                    {
                        temp = temp.next;                   
                        i++;
                    }
                    data = temp.next.data;
                    temp.next = temp.next.next;
                    size -= 1;
                    return data;
                }
            }
        }

        //Two pointer
        //Time: O(n)
        //Space: O(1)
        public int RemoveNode(int num)
        {
            if (num <= 0 || num > size)
                return -1;
            else
            {
                if (IsEmpty())
                    return -1;
                int data;
                Node slower = head;
                Node faster = head;

                // iterate first n nodes using faster
                for (int i = 0; i < num; i++)
                    faster = faster.next;

                // if faster is already null, it means we have to delete head itself
                if (faster == null)
                {
                    data = head.data;
                    head = head.next;
                    size -= 1;
                    return data;
                }

                // iterate till faster reaches the last node of list
                while (faster.next != null)
                {
                    faster = faster.next;
                    slower = slower.next;
                }
                data = slower.next.data;
                slower.next = slower.next.next; // remove the nth node from last
                size -= 1;
                return data;
            }
        }

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddToTail(4);
            linkedList.AddToTail(5);
            linkedList.AddToTail(6);
            linkedList.AddToTail(7);
            linkedList.AddToTail(8);
            linkedList.Display();

            Console.WriteLine("Enter the number from the last which you want to remove: ");
            int num = int.Parse(Console.ReadLine());

            int res = linkedList.RemoveFromLast(num);
            if (res != -1)
                Console.WriteLine("Data removed: " + res);
            linkedList.Display();

            LinkedList linkedList1 = new LinkedList();
            linkedList1.AddToTail(4);
            linkedList1.AddToTail(5);
            linkedList1.AddToTail(6);
            linkedList1.AddToTail(7);
            linkedList1.AddToTail(8);
            linkedList1.Display();

            Console.WriteLine("Enter the number from the last which you want to remove: ");
            int num1 = int.Parse(Console.ReadLine());

            int res1 = linkedList1.RemoveNode(num1);
            if (res1 != -1)
                Console.WriteLine("Data removed: " + res1);
            linkedList1.Display();
            Console.ReadKey();
        }
    }
}
