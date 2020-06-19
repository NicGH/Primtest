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
        public Node Head { get; set; }
        Node insert;

        public void Add(int value)
        {
            insert = new Node(value);
            if (Head == null)
            {
                Head = insert;
                return;
            }

            current = Head;
            if (value <= current.Value)
            {
                insert.Next = Head;
                Head = insert;
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

        public void Print()
        {
            if (Head == null)
            {
                Console.WriteLine("list is empty!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Die Liste enthält folgende Zahlen:");
                System.Threading.Thread.Sleep(500);
                current = Head;
                while (current != null)
                {
                    Console.Write(current.Value + "; ");
                    current = current.Next;
                    System.Threading.Thread.Sleep(2);
                }
                Console.WriteLine();
                Console.WriteLine("Zum Fortfahren Enter drücken");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            }    
        }
        public void FillUntil(int value)
        {
            int Counter = 1;
            for (int i = 1; i <= value; i++)
            {
                Add(Counter);
                Counter++;
            }
            Console.WriteLine("Die Zahlen 1 bis " + value + " wurden eingefügt");
            System.Threading.Thread.Sleep(250);
            Console.WriteLine("Zum Fortfahren Enter drücken");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}

class Primtest
{
    Node root;
    Node current;

    void Eratosthenes(LinkedList List)
    {
        root = List.Head;
        current = root;
        int counter = 0;
        Node divider;

        Console.WriteLine(); Console.WriteLine();
        Console.WriteLine("Das Sieb beginnt!");
        System.Threading.Thread.Sleep(500);

        Console.WriteLine();
        if (current == null)
        {
            Console.WriteLine("The list is empty!");
            return;
        }
        do
        {
            counter++;
            if (current.Value != counter)
            {
                Console.WriteLine("The list must start with 1 and be both continuous and sorted in ascending order.");
                return;
            }
//           Console.WriteLine(current.Value + " = " + counter); // DEBUG
            current = current.Next;

        } while (current != null);

        if (counter < 3)
        {
            Console.WriteLine("Ende der Liste erreicht.");
            Console.WriteLine("Die Primzahlen lauten:");
            Console.WriteLine("2");
            return;
        }
        else
        {
            root = root.Next;
            current = root;
            divider = root;
            int limit = (int)Math.Floor(Math.Sqrt(counter));
            while (divider.Value <= limit)
            {
                Console.WriteLine("Teiler von " + divider.Value + " werden geprüft... entfernt werden:");
                System.Threading.Thread.Sleep(250);
                while (current.Next != null) // solange nächstes Element existiert
                {
                    if (current.Next.Next != null) // und auch übernächstes Element existiert
                    {
                        if (current.Next.Value % divider.Value == 0 && current.Next.Value != divider.Value) // falls nächstes Element geteilt werden kann
                        {
                            Console.Write(current.Next.Value + "; ");
                            current.Next = current.Next.Next; // dann überspringen
                            System.Threading.Thread.Sleep(divider.Value*5);
                        }
                        current = current.Next; // und zum nächsten Element wechseln
                    }
                    else // sonst, falls kein übernächstes Element existiert
                    {
                        if (current.Next.Value % divider.Value == 0 && current.Next.Value != divider.Value) // aber nächstes Element geteilt werden kann
                        {
                            Console.Write(current.Next.Value + "; ");
                            current.Next = null; // beende Liste bei diesem Element
                         }
                        else
                        {
                            current = current.Next;  // sonst beende nach dem nächsten Element
                        }
                    }
                }
                //Console.WriteLine("Ende der Liste erreicht.");  // DEBUG
                Console.WriteLine();
                Console.WriteLine();
                current = root; // gehe zum Anfang der Liste
                divider = divider.Next;
                System.Threading.Thread.Sleep(1000);
            }
            current = root;
            Console.WriteLine("Die Liste wurde gesiebt.");
            Console.WriteLine("Zum Fortfahren Enter drücken");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            Console.WriteLine();
            Console.WriteLine("Die Primzahlen bis " + counter + " lauten:");
            int i = 0;
            while (current != null)
            {
                if (current.Next != null)
                {
                    Console.Write(current.Value + ", ");
                    current = current.Next;
                    i++;
                    System.Threading.Thread.Sleep(5000/counter);
                }
                else
                {
                    Console.Write(current.Value);
                    current = current.Next;
                    i++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("(" + i + " Primzahlen)");
        }
    }


    class Program
    {
        static void Main(/*string[] args*/)
        {
            LinkedList Prim = new LinkedList();
            Prim.FillUntil(5000);
            Prim.Print();
            Primtest Sieb = new Primtest();
            Sieb.Eratosthenes(Prim);

            Console.WriteLine();
            Console.WriteLine("Zum Beenden Enter drücken");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}
