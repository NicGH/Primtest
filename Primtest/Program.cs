using System;
using Primtest;

namespace Primtest
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }


    public class LinkedList
    {
        Node current;
        public Node head { get; set; }
        Node insert;

        public void add(int value)
        {
            insert = new Node(value);
            if (head == null)
            {
                head = insert;
                return;
            }

            current = head;
            if (value <= current.Value)
            {
                insert.Next = head;
                head = insert;
                return;
            }
            else
            {
                if (current.Next == null)
                {
                    current.Next = insert;
                    return;
                }
                else
                {
                    while (value > current.Next.Value)
                    {
                        current = current.Next;
                        if (current.Next == null)
                        {
                            current.Next = insert;
                            return;
                        }
                    }
                    insert.Next = current.Next;
                    current.Next = insert;

                }
            }
        }

        public void print()
        {
            if (head == null)
            {
                Console.WriteLine("list is empty!");
            }
            else
            {
                current = head;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }    
        }
        public void fillUntil(int value)
        {
            int Counter = 1;
            for (int i = 1; i <= value; i++)
            {
                add(Counter);
                Counter++;
            }
        }
    }
}

class Eratosthenes // nächster Task: Atkin
{
    Node root;

    void Sieb(LinkedList List)
    {
        root = List.head;
        if (List == null)
        {
            Console.WriteLine("The list is empty!");
        }
        do {
            int counter = 1;
            if (root.Value != counter)
                {
                Console.WriteLine("The list must start with 1 and be both continuous and sorted in ascending order.");
                return;
            }
            root = root.Next;
            counter++;
        } while (root.Next != null);

    }


    class Program
    {
        static void Main(string[] args)
        {
            LinkedList Prim = new LinkedList();
            Prim.add(0);
            Prim.fillUntil(100);
            Prim.print();

            //Console.WriteLine("Press Enter to quit");
            //while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}
