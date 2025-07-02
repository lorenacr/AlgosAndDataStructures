using System.Collections;
using System.Collections.Generic;

namespace AlgosAndDataStructures.LinkedLists;

/// <summary>
/// A node in the LinkedList.
/// As this is a Singly Linked List Node, every node has a reference to the next node,
/// except the one in the tail. 
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedListNode<T>
{
    /// <summary>
    /// Every node has a value.
    /// </summary>
    public T Value { get; set; }
    
    /// <summary>
    /// A reference to the next node in the linked list.
    /// If it's the tail node, then this is null.
    /// </summary>
    public LinkedListNode<T> Next { get; set; }

    /// <summary>
    /// Basic constructor.
    /// </summary>
    /// <param name="value"></param>
    public LinkedListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

/// <summary>
/// A singly linked list.
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedList<T> : ICollection<T>
{
    /// <summary>
    /// The first node in the list, or null if the list is empty. 
    /// </summary>
    private LinkedListNode<T> _head { get; set; }
    
    /// <summary>
    /// The last node in the list, or null if the list is empty.
    /// </summary>
    private LinkedListNode<T> _tail { get; set; }
    
    public T Head => _head.Value;

    public T Tail => _tail.Value;
    
    /// <summary>
    /// Number of items in the list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Whether the list is readonly or not.
    /// </summary>
    public bool IsReadOnly => false;
    
    /// <summary>
    /// Enumerates over the linked list values.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>The enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Enumerates over the linked list values.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>The enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Add item to the start of the linked list.
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddHead(T item)
    {
        // Saves the old head to set reference.
        var oldHead = _head;
        
        // Point head to new item and sets next to old head.
        _head = new LinkedListNode<T>(item)
        {
            Next = oldHead
        };

        Count++;

        if (Count == 1)
        {
            _tail = _head;
        }
    }

    /// <summary>
    /// Add item to the end of the linked list.
    /// Complexity: O(1) 
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddTail(T item)
    {
        var newTailNode = new LinkedListNode<T>(item);
        
        // If the linked list is empty, the item is head and tail.
        if (Count == 0)
        {
            _head = newTailNode;
        }
        // Points the reference of the current tail to the new item.
        else
        {
            _tail.Next = newTailNode;
        }
        
        // Changes the tail to be the new item.
        _tail = newTailNode;

        Count++;
    }
    
    /// <summary>
    /// Add item to the front of the linked list.
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void Add(T item)
    {
        AddHead(item);
    }

    /// <summary>
    /// Removes all the nodes from the linked list.
    /// Complexity: O(1)
    /// </summary>
    public void Clear()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    /// <summary>
    /// Checks whether the item is contained in the list.
    /// Complexity: O(n)
    /// </summary>
    /// <param name="item">The item to be verified if exists in the list.</param>
    /// <returns>True if the item is found. Otherwise, false.</returns>
    public bool Contains(T item)
    {
        var current = _head;

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
        var current = _head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Removes the head item.
    /// Complexity: O(1)
    /// </summary>
    /// <returns>True if removed, false otherwise.</returns>
    public bool RemoveHead()
    {
        if (Count == 0) 
            return true;

        if (Count == 1)
        {
            _head = null;
            _tail = null;

            return true;
        }
        
        _head = _head.Next;

        Count--;

        return true;
    }

    /// <summary>
    /// Removes the tail item.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>True if removed, false otherwise.</returns>
    public bool RemoveTail()
    {
        if (Count == 0)
            return true;
        
        if (Count == 1)
        {
            _head = null;
            _tail = null;

            return true;
        }

        var current = _head;
        while (current.Next != _tail)
        {
            current = current.Next;
        }
        
        current.Next = null;
        _tail = current;
        
        Count--;
        
        return true;
    }
    
    /// <summary>
    /// Removes an item from the linked list.
    /// Complexity: O(n)
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    /// <returns>True if removed, false otherwise.</returns>
    public bool Remove(T item)
    {
        LinkedListNode<T> previous = null;
        var current = _head;
        
        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                // If it is not the head
                if (previous != null)
                {
                    previous.Next = current.Next;
                    
                    // If the current node is the tail node, sets new tail as previous.
                    if (current.Next == null)
                        _tail = previous;

                    Count--;
                }
                else
                {
                    RemoveHead();
                }
                
                previous = current;
                current.Next = current.Next.Next;
                
                return true;
            }
            
            previous = current;
            current = current.Next;
        }
        
        return false;
    }
    
    /// <summary>
    /// Converts the list as string.
    /// Method used for debugging purposes only.
    /// Complexity: O(n²) because of +=.
    /// </summary>
    public string ConvertToString()
    {
        var listAsString = string.Empty;
        
        var current = _head;
        while (current != null)
        {
            listAsString += current.Value + " -> ";
            current = current.Next;
        }

        listAsString +="NULL";
        return listAsString;
    }
}