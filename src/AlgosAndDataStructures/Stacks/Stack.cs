using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgosAndDataStructures.Stacks;

/// <summary>
/// Last In First Out (LIFO) collection.
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
    /// Adds an item to the stack.
    /// </summary>
    /// <param name="item"></param>
    public void Push(T item)
    {
        if (_size == _array.Length)
        {
            var newLength =  _array.Length * 2;
            
            var newArray = new T[newLength];
            _array.CopyTo(newArray, 0);
            _array = newArray;
        }
        
        _array[_size] = item;
        _size++;
    }

    /// <summary>
    /// Removes and returns the last item in the stack.
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        
        return _array[--_size];
    }

    /// <summary>
    /// Returns the last item from the stack without removing it.
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        
        return _array[_size - 1];
    }

    public int Count => _size;

    public void Clear()
    {
        _size = 0;
    }

    /// <summary>
    /// Enumerates each item from the stack in LIFO order, maintaining
    /// the stack unaltered. 
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = _size - 1; i >= 0; i--)
        {
            yield return _array[i];
        }
    }

    /// <summary>
    /// Enumerates each item from the stack in LIFO order, maintaining
    /// the stack unaltered. 
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}