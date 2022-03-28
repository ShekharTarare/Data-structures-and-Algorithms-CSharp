using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_CSharp
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int _data, Node _next) //to initialize the data and the link to the next node
        {
            data = _data;
            next = _next;
        }
    }
    class LinkedList
    {
        private Node head; //it will point to the first node
        private Node tail; //it will point to the last node
        private int size; //it will keep track of size of the linked list

        public LinkedList() //to initialize the head, tail and size
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

        public void AddLast(int data)
        {
            Node newNode = new Node(data, null); //creating a new node
            if (IsEmpty()) //checking if linked list is empty
                head = newNode; //pointing the head to the new node
            else
                tail.next = newNode; //making the tail node point to the new node
            tail = newNode; //tail node pointing to new node
            size += 1; //increasing size after insertion
        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data, null);
            if (IsEmpty())
            {
                head = newNode; //if empty then making head and tail point to new node
                tail = newNode;
            }
            else
            {
                newNode.next = head; //if not empty then making the head point to the new node
                head = newNode;
            }           
            size += 1;
        }

        public void AddAny(int data, int position)
        {
            if (position <= 0 || position >= size) 
            {
                Console.WriteLine("Invalid Position!");
                return;
            }
            int positionTracker = 1;
            Node temp = head;
            Node newNode = new Node(data, null);
            
            while(positionTracker < position - 1) //move until we get the node which is lesser than the position
            {
                temp = temp.next;
                positionTracker += 1;
            }
            newNode.next = temp.next; //connecting the newNode
            temp.next = newNode;
            size += 1;
        }

        public int RemoveFirst()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Linkedlist is empty!");
                return -1;
            }
            else
            {
                int data = head.data;
                head = head.next;
                size -= 1;
                if (IsEmpty())
                    tail = null;
                return data;
            }
        }

        public int RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linkedlist is empty!");
                return -1;
            }
            else
            {
                int data;
                if (size == 1) //if only one node 
                {
                    data = head.data;
                    head = tail = null;
                    size -= 1;
                    return data;
                }
                else
                {
                    Node temp = head;
                    int i = 1;
                    while (i < size - 1)
                    {
                        temp = temp.next;
                        i += 1;
                    }
                    tail = temp;
                    temp = temp.next;
                    data = temp.data;
                    tail.next = null;                    
                    size -= 1;
                    return data;
                }
            }            
        }

        public int RemoveAny(int position)
        {
            if (position <= 0 || position >= size - 1)
            {
                Console.WriteLine("Invalid Position!");
                return -1;
            }
            int positionTracker = 1;
            Node temp = head;
            while(positionTracker < position - 1)
            {
                temp = temp.next;
                positionTracker += 1;
            }
            int data = temp.next.data;
            temp.next = temp.next.next;
            size -= 1;
            return data;
        }

        public int Search(int key)
        {
            Node temp = head;
            int index = 0;
            while(temp != null)
            {
                index++;
                if (key == temp.data)
                    return index;
                temp = temp.next;
            }
            return -1;
        }

        public void InsertSorted(int data)
        {
            Node newNode = new Node(data, null);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node p = head;
                Node q = head; 
                while (p != null && p.data < data)
                {
                    q = p;
                    p = p.next;
                }
                if(p == head) //if only one node
                {
                    newNode.next = head;
                    head = newNode;
                }
                else
                {
                    newNode.next = q.next;
                    q.next = newNode;
                }
            }
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
        }

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.AddLast(4);
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            linkedList.AddLast(1);
            linkedList.Display();

            linkedList.AddFirst(0);
            Console.WriteLine();
            linkedList.Display();

            linkedList.AddAny(99, 2);
            Console.WriteLine();
            linkedList.Display();
            Console.WriteLine();

            int removedData = linkedList.RemoveFirst();
            if (removedData != -1)
                Console.WriteLine("Data removed: " + removedData);
            linkedList.Display();
            Console.WriteLine();

            int removedDataAtLast = linkedList.RemoveLast();
            if (removedDataAtLast != -1)
                Console.WriteLine("Data removed: " + removedDataAtLast);
            linkedList.Display();
            Console.WriteLine();

            int removedDataAtAny = linkedList.RemoveAny(2);
            if (removedDataAtAny != -1)
                Console.WriteLine("Data removed: " + removedDataAtAny);
            linkedList.Display();
            Console.WriteLine();

            int index = linkedList.Search(29);
            if (index == -1)
                Console.WriteLine("Not found!");
            else
            {
                Console.WriteLine("Found at index: " + index);
            }
            Console.WriteLine();

            int removedDataAtLast1 = linkedList.RemoveLast();
            if (removedDataAtLast1 != -1)
                Console.WriteLine("Data removed: " + removedDataAtLast1);
            linkedList.Display();
            Console.WriteLine();

            int removedDataAtLast2 = linkedList.RemoveLast();
            if (removedDataAtLast2 != -1)
                Console.WriteLine("Data removed: " + removedDataAtLast2);
            linkedList.Display();
            Console.WriteLine();

            int removedDataAtLast3 = linkedList.RemoveLast();
            if (removedDataAtLast3 != -1)
                Console.WriteLine("Data removed: " + removedDataAtLast3);
            linkedList.Display();
            Console.WriteLine();

            linkedList.InsertSorted(3);
            linkedList.InsertSorted(9);
            linkedList.InsertSorted(5);
            linkedList.InsertSorted(1);
            linkedList.InsertSorted(3);
            linkedList.Display();
            Console.ReadKey();
        }
    }
}
