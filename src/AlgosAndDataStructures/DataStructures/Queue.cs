using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AlgosAndDataStructures.DataStructures;

/// <summary>
/// First In First Out (FIFO) collection.
/// This class has been optimized and tested for memory leaks.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Queue<T> : IEnumerable<T>
{
    /// <summary>
    /// Array of items contained in queue.
    /// </summary>
    private T[] _array;

    /// <summary>
    /// The index of the first item in the queue. 
    /// </summary>
    private int _head;

    /// <summary>
    /// The index of the last item in the queue.
    /// It starts with -1 to track the tail with the maximum performance.  
    /// </summary>
    private int _tail = -1;
    
    private int _size;

    /// <summary>
    /// Basic constructor.
    /// </summary>
    public Queue()
    {
        this._array = new T[4];
    }
    
    /// <summary>
    /// Constructor tha initializes queue from an existing collection.
    /// </summary>
    /// <param name="collection">The collection from which the queue should be initialized.</param>
    public Queue(IEnumerable<T> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);
        
        this._array = collection.ToArray();
        this._size = this._array.Length;
        
        if (this._size > 0)
        {
            this._tail = this._size - 1;
        }
        else
        {
            this._array = new T[4];
            this._tail = -1;
        }
    }

    /// <summary>
    /// The number of items in the queue.
    /// </summary>
    public int Count => this._size;

    /// <summary>
    /// Adds an item to the end of the queue.
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void Enqueue(T item)
    {
        if (this._size == this._array.Length)
        {
            var newLength =  this._array.Length * 2;
            
            var newArray = new T[newLength];
            this._array.CopyTo(newArray, 0);
            this._array = newArray;
        }

        // If the tail didn't start with -1, we would need to check the count every time to set the tail right, 
        // which would consume computational resources unnecessarily.
        this._array[++this._tail] = item;
        this._size++;
    }

    /// <summary>
    /// Returns item from the start of the queue and removes it.
    /// Complexity: O(1)
    /// </summary>
    /// <returns>The item on the beginning of the queue.</returns>
    public T Dequeue()
    {
        if (this._size == 0)
            throw new InvalidOperationException("Queue is empty.");
        
        var item = this._array[this._head];
        
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            this._array[this._head] = default!;

        this._head++;
        this._size--;
        return item;
    }
    
    /// <summary>
    /// Returns item from the start of the queue without removing it.
    /// Complexity: O(1)
    /// </summary>
    /// <returns>The item on the beginning of the queue.</returns>
    public T Peek()
    {
        if (this._size == 0)
            throw new InvalidOperationException("Queue is empty.");
        
        return this._array[this._head];
    }
    
    /// <summary>
    /// Clears the queue.
    /// Complexity: O(n)
    /// </summary>
    public void Clear()
    {
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            Array.Clear(this._array, 0, this._array.Length);
        
        this._size = 0;
        this._head = 0;
        this._tail = -1;
    }
    
    /// <summary>
    /// Enumerates over the collection values.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>The element in the collection at the current position of the enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = this._head; i <= this._tail; i++)
        {
            yield return this._array[i];
        }
    }

    /// <summary>
    /// Enumerates over the collection values.
    /// Complexity: O(n)
    /// </summary>
    /// <returns>The element in the collection at the current position of the enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}