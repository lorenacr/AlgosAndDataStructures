using System;
using AlgosAndDataStructures.LinkedLists;

namespace AlgosAndDataStructures;

class Program
{
    static void Main(string[] args)
    {
        TestingTheLinkedList();
    }

    public static void TestingTheLinkedList()
    {
        var linkedList = new LinkedList<int>();
        
        linkedList.AddTail(10);
        linkedList.AddTail(20);
        linkedList.AddHead(5);
        linkedList.AddTail(30);
        
        // Should print: 5 -> 10 -> 20 -> 30 -> NULL
        Console.WriteLine("Original list: " + linkedList.ConvertToString());
        
        // Should print 4
        Console.WriteLine("Items count: " + linkedList.Count); 
        
        linkedList.Remove(20);
        
        // Should print: 5 -> 10 -> 30 -> NULL
        Console.WriteLine("After deleting 20: " + linkedList.ConvertToString());

        Console.ReadKey();
    }
}
