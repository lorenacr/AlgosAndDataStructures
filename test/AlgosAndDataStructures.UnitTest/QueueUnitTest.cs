using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace AlgosAndDataStructures.UnitTest;

public class QueueUnitTest
{
    private Queue<int> _queue;

    public QueueUnitTest()
    {
        this._queue = new Queue<int>([10,20,30,40,50,60,70,80,90,100]);
    }

    [Fact]
    public void Peek_ShouldGetFirstItemWithoutRemovingIt()
    {
        // Arrange
        var expected = 10;
        
        // Act
        var actual = this._queue.Peek();
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expected, this._queue.Peek());
    }
    
    [Fact]
    public void Peek_WhenStackIsEmpty_ShouldThrowInvalidOperationException()
    {
        // Arrange
        this._queue.Clear();
        
        // Act / Assert
        Assert.Throws<InvalidOperationException>(() => this._queue.Peek());
    }

    [Fact]
    public void Dequeue_ShouldGetFirstItemAndRemoveIt()
    {
        // Arrange
        var expected = 2;
        this._queue.Clear();
        this._queue.Enqueue(expected);
        this._queue.Enqueue(4);
        this._queue.Enqueue(6);
        
        // Act
        var actual = this._queue.Dequeue();
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.NotEqual(expected, this._queue.Peek());
    }
    
    [Fact]
    public void Dequeue_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
    {
        // Arrange
        this._queue.Clear();
        
        // Act / Assert
        Assert.Throws<InvalidOperationException>(() => this._queue.Dequeue());
    }
    
    [Fact]
    public void Enqueue_ShouldAddItemToTheEnd()
    {
        // Arrange
        var expected = 1001;
        this._queue.Clear();
        this._queue.Enqueue(1);
        this._queue.Enqueue(expected);
        
        // Act
        this._queue.Enqueue(expected);
        
        // Assert
        Assert.NotEqual(expected, this._queue.Peek());
        Assert.Contains(expected, this._queue);
    }

    [Fact]
    public void Clear_ShouldRemoveAllItemsFromStack()
    {
        // Act
        this._queue.Clear();

        // Assert
        Assert.Empty(this._queue);
    }
    
    [Fact]
    public void Clear_ShouldReleaseMemory()
    {
        // Arrange
        var queue = new Queue<byte[]>();
        var weakRefs = new System.Collections.Generic.List<WeakReference>();
        for (var i = 0; i < 100; i++)
        {
            var data = new byte[1000000];
            queue.Enqueue(data);
            weakRefs.Add(new WeakReference(data));
        }
    
        // Act
        queue.Clear();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    
        // Assert
        Assert.True(weakRefs.Count(r => r.IsAlive) < 5);
    }

    [Theory]
    [InlineData(-1, false)]
    [InlineData(10, true)]
    [InlineData(40, true)]
    [InlineData(80, true)]
    [InlineData(100, true)]
    public void Contains_ShouldReturnCorrectly(int item, bool expected)
    {
        // Act
        var actual = this._queue.Contains(item);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Count_ShouldReturnCorrectly()
    {
        // Arrange
        var expected = 10;
        
        // Act
        var actual = this._queue.Count;
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Count_ShouldReturnZeroWhenListIsEmpty()
    {
        // Arrange
        var expected = 0;
        this._queue.Clear();
        this._queue = new Queue<int>(new List<int>());
        
        // Act
        var actual = this._queue.Count;
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Enqueue_OneMillionItems_ShouldNotBreak()
    {
        // Arrange
        var expected = 1000000;
        this._queue.Clear();
        
        // Act
        for (int i = 0; i < expected; i++) 
            this._queue.Enqueue(i);
        
        // Assert
        Assert.Equal(expected, this._queue.Count);
    }
    
    [Fact]
    public void Dequeue_HundredThousandItems_ShouldCompleteInUnder100Milliseconds()
    {
        // Arrange
        this._queue.Clear();
        for (var i = 0; i < 100000; i++) 
            this._queue.Enqueue(i);
        
        // Act
        var stopwatch = Stopwatch.StartNew();
        while (this._queue.Count > 0) 
            this._queue.Dequeue();
        stopwatch.Stop();
        
        // Assert
        Assert.True(stopwatch.ElapsedMilliseconds < 100);
    }
}