using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
This can be solved by reversing the 2nd half and compare the two halves. Let's start with an example [1, 1, 2, 1].

In the beginning, set two pointers fast and slow starting at the head.

1 -> 1 -> 2 -> 1 -> null 
sf
(1) Move: fast pointer goes to the end, and slow goes to the middle.

1 -> 1 -> 2 -> 1 -> null 
          s          f
(2) Reverse: the right half is reversed, and slow pointer becomes the 2nd head.

1 -> 1    null <- 2 <- 1           
h                      s
(3) Compare: run the two pointers head and slow together and compare.

1 -> 1    null <- 2 <- 1             
     h            s
 
*/
namespace PalindromeLinkedList
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
            if (IsEmpty())
                head = newNode;
            else
                tail.next = newNode;
            tail = newNode;
            size += 1;
        }

        public Node Reverse(Node node)
        {
            Node prev = null, next;
            while (node != null)
            {
                next = node.next;
                node.next = prev;
                prev = node;
                node = next;
            }
            return prev;
        }

        public bool CheckPalindrome()
        {
            Node faster = head, slower = head;
            while(faster != null && faster.next != null) //getting the middle of the linked list and pointing slower to that location
            {
                faster = faster.next.next;
                slower = slower.next;
            }

            if (faster != null)  // odd nodes: let right half smaller
                slower = slower.next;

            slower = Reverse(slower); //reversing the right list
            faster = head;
            while(slower != null) //Compare the data of left and right linked list
            {
                if (slower.data != faster.data)
                    return false;
                slower = slower.next;
                faster = faster.next;
            }
            return true;
        }

        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddLast(2);
            linkedList.AddLast(1);
            linkedList.Display();
            var res = linkedList.CheckPalindrome();
            if (res)
                Console.WriteLine("It's palindrome!");
            else
                Console.WriteLine("It's not palindrome!");
            Console.ReadKey();
        }
    }
}
