using System;
using System.Diagnostics.CodeAnalysis;

namespace AlgosAndDataStructures;

[ExcludeFromCodeCoverage]
class Program
{
    static void Main(string[] args)
    {
        TestingTheLinkedList();
        
        TestingTheStack();
        
        TestingTheQueue();
        
        Console.ReadKey();
    }
    
    private static void TestingTheLinkedList()
    {
        Console.WriteLine("Starting Linked List tests:");
        
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
        
        Console.WriteLine(string.Empty);
    }
    
    private static void TestingTheStack()
    {
        Console.WriteLine("Starting Stack tests:");
        
        var stack = new Stack<int>();
        
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        
        // Should print 30
        Console.WriteLine("Peek: " + stack.Peek());

        // Should print 30
        Console.WriteLine("First pop: " + stack.Pop());
        
        // Should print 20
        Console.WriteLine("Last pop: " + stack.Pop());
        
        Console.WriteLine(string.Empty);
    }
    
    private static void TestingTheQueue()
    {
        Console.WriteLine("Starting Queue tests:");
        
        var queue = new Queue<int>();
        
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        
        // Should print 10
        Console.WriteLine("Peek: " + queue.Peek());

        // Should print 10
        Console.WriteLine("First Dequeue: " + queue.Dequeue());
        
        // Should print 20
        Console.WriteLine("Last Dequeue: " + queue.Dequeue());
        
        Console.WriteLine(string.Empty);
    }
}
