using System;
using Primtests;

namespace Primtests
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

class Primtest
{
    Node root;
    Node current;

    void Eratosthenes (LinkedList List)
    {
        root = List.head;
        current = root;
        int counter = 1;
        if (current == null)
        {
            Console.WriteLine("The list is empty!");
            return;
        }
        do {
            if (current.Value != counter)
                {
                Console.WriteLine("The list must start with 1 and be both continuous and sorted in ascending order.");
                return;
            }
            current = current.Next;
            counter++;
        } while (current != null);

        root = root.Next;
        current = root;
        int maxIteration = counter;
        counter = 2;
        for (int i = 2; i < Math.Floor(Math.Sqrt(maxIteration)); i++)
            {
            while (current != null)
            {
                if (current.Value % counter == 0)
                {
                    current.Next = current.Next.Next;
                    current = current.Next;
                }
            }
        }
        current = root;
        while (current != null)
            {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LinkedList Prim = new LinkedList();
            Prim.fillUntil(100);
            Prim.print();
            Primtest Sieb = new Primtest();
            Sieb.Eratosthenes(Prim);
            

            //Console.WriteLine("Press Enter to quit");
            //while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}
