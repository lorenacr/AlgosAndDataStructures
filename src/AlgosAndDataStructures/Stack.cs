using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AlgosAndDataStructures;

/// <summary>
/// Last In First Out (LIFO) collection.
/// This class has been optimized and tested for memory leaks.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Stack<T> : IEnumerable<T>
{
    /// <summary>
    /// Array of items contained in stack.
    /// </summary>
    private T[] _array =  new T[1];

    /// <summary>
    /// Number of items in stack.
    /// </summary>
    private int _size;

    /// <summary>
    /// Returns how many items are in the stack.
    /// </summary>
    public int Count => this._size;
    
    /// <summary>
    /// Adds an item to the stack.
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to be added to the stack.</param>
    public void Push(T item)
    {
        if (this._size == this._array.Length)
        {
            var newLength =  this._array.Length * 2;
            
            var newArray = new T[newLength];
            this._array.CopyTo(newArray, 0);
            this._array = newArray;
        }
        
        this._array[_size] = item;
        this._size++;
    }

    /// <summary>
    /// Removes and returns the last item in the stack.
    /// Complexity: O(1)
    /// </summary>
    /// <returns>The last item in the stack.</returns>
    public T Pop()
    {
        if (this._size == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        
        var item = this._array[--_size];
        
        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            this._array[_size] = default!;
        
        return item;
    }

    /// <summary>
    /// Returns the last item in the stack without removing it.
    /// Complexity: O(1)
    /// </summary>
    /// <returns>The last item in the stack.</returns>
    public T Peek()
    {
        if (this._size == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        
        return this._array[_size - 1];
    }

    /// <summary>
    /// Clears the stack.
    /// Complexity: O(n)
    /// </summary>
    public void Clear()
    {
        Array.Clear(this._array, 0, this._array.Length);
        this._size = 0;
    }

    /// <summary>
    /// Enumerates each item from the stack in LIFO order, maintaining
    /// the stack unaltered.
    ///  Complexity: O(n)
    /// </summary>
    /// <returns>The element in the collection at the current position of the enumerator.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = this._size - 1; i >= 0; i--)
        {
            yield return this._array[i];
        }
    }

    /// <summary>
    /// Enumerates each item from the stack in LIFO order, maintaining
    /// the stack unaltered.
    ///  Complexity: O(n)
    /// </summary>
    /// <returns>The element in the collection at the current position of the enumerator.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}