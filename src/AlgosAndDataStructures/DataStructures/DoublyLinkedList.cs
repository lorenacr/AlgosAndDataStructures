using System.Collections;
using System.Collections.Generic;

namespace AlgosAndDataStructures.DataStructures;

/// <summary>
/// A node in the LinkedList.
/// As this is a Doubly Linked List Node, every node has a reference to the
/// previous and the next node.
/// </summary>
/// <typeparam name="T"></typeparam>
public class DoublyLinkedListNode<T>
{
    /// <summary>
    /// Every node has a value.
    /// </summary>
    public T Value { get; set; }
    
    /// <summary>
    /// A reference to the previous node in the linked list.
    /// If it's the first node, then this is null.
    /// </summary>
    public DoublyLinkedListNode<T> Previous { get; set; }
    
    /// <summary>
    /// A reference to the next node in the linked list.
    /// If it's the tail node, then this is null.
    /// </summary>
    public DoublyLinkedListNode<T> Next { get; set; }

    /// <summary>
    /// Basic constructor.
    /// </summary>
    public DoublyLinkedListNode(T value)
    {
        Value = value;
    }
}

/// <summary>
/// A doubly linked list.
/// </summary>
/// <typeparam name="T"></typeparam>
public class DoublyLinkedList<T> : ICollection<T>
{
    /// <summary>
    /// The first node in the list, or null if the list is empty.
    /// </summary>
    private DoublyLinkedListNode<T> _head { get; set; }
    
    /// <summary>
    /// The last node in the list, or null if the list is empty.
    /// </summary>
    private DoublyLinkedListNode<T> _tail { get; set; }

    public T Head => this._head.Value;

    public T Tail => this._tail.Value;
    
    /// <summary>
    /// Number of itemns in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Whether the list is readonly or not.
    /// </summary>
    public bool IsReadOnly => false;
    
    /// <summary>
    /// Add item to the start of the linked list.
    ///  Complexity: O(1) 
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddHead(T item)
    {
        // Saves the old head to set reference.
        var oldHead = this._head;
        
        // Point head to new item and sets next head to old head.
        this._head = new DoublyLinkedListNode<T>(item) { Next = oldHead };
        
        this.Count++;
        
        if (this.Count == 1)
            this._tail = this._head;
    }

    /// <summary>
    /// Add item to the end of the linked list.
    /// Complexity: O(1) 
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddTail(T item)
    {
        var oldTail = this._tail;
        var newTailNode = new DoublyLinkedListNode<T>(item) { Previous = oldTail };

        // If the linked list is empty, the item is head and tail.
        if (this.Count == 0)
        {
            this._head = newTailNode;
        }
        // Points the reference of the current tail to the new item.
        else
        {
            this._tail.Next = newTailNode;
        }
        
        // Changes the tail to be the new item.
        this._tail = newTailNode;
        
        this.Count++;
    }

    /// <summary>
    /// Add item to the start of the linked list.
    ///  Complexity: O(1) 
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void Add(T item)
    {
        this.AddHead(item);
    }

    /// <summary>
    /// Removes all nodes from the linked list.
    /// Complexity: O(n)
    /// </summary>
    public void Clear()
    {
        var current = this._head;
        while (current != null)
        {
            var temp = current;
            current = current.Next;
            temp = default;
        }

        this._head = null;
        this._tail = null;

        this.Count = 0;
    }

    /// <summary>
    /// Checks whether the item is contained in the list.
    /// Complexity: O(n)
    /// </summary>
    /// <param name="item">The item to be verified if exists in the list.</param>
    /// <returns>True if the item is found. Otherwise, false.</returns>
    public bool Contains(T item)
    {
        var current = this._head;

        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;
            
            current = current.Next;
        }
        
        return false;
    }

    /// <summary>
    /// Copies the node values into the array.
    /// Complexity: O(n)
    /// </summary>
    /// <param name="array">The array to copy the values to.</param>
    /// <param name="arrayIndex">The index of the array to start copying at.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        var current = this._head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Finds an item in the list.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>The item if it exists in the list, null otherwise.</returns>
    public DoublyLinkedListNode<T> Find(T item)
    {
        var current = this._head;
        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }
    
    /// <summary>
    /// Removes an item.
    /// Complexity: O(1)
    /// </summary>
    /// <returns>True if removed, false otherwise.</returns>
    public bool Remove(T item)
    {
        var itemFound = this.Find(item);
        if (itemFound == null)
            return false;
        
        var previous = itemFound.Previous;
        var next = itemFound.Next;

        // If previous is null, we're removing the head node.
        if (previous == null)
        {
            this._head = next;
            
            if (this._head != null)
                this._head.Previous = null;
        }
        else
        {
            previous.Next = next;
        }

        // If next is null, we're removing the tail.
        if (next == null)
        {
            this._tail = previous;
            
            if (this._tail != null)
                this._tail.Next = null;
        }
        else
        {
            next.Previous = previous;
        }
        
        this.Count--;

        return true;
    }
    
    /// <summary>
    /// Enumerates over the linked list values.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>The element in the collection at the current position of the enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = this._head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Enumerates over the doubly linked list values.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>The element in the collection at the current position of the enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}