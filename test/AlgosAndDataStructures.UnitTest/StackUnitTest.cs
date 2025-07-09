using System;
using System.Diagnostics;
using System.Linq;
using AlgosAndDataStructures.Stacks;
using Xunit;

namespace AlgosAndDataStructures.UnitTest;

public class StackUnitTest
{
    private Stacks.Stack<int> _stack;

    public StackUnitTest()
    {
        this._stack = new Stacks.Stack<int>();

        for (int i = 0; i < 100; i++)
        {
            this._stack.Push(i);
        }
    }

    [Fact]
    public void Peek_ShouldGetLastItemWithoutRemovingIt()
    {
        // Arrange
        var expected = 99;
        
        // Act
        var actual = this._stack.Peek();
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expected, this._stack.Peek());
    }
    
    [Fact]
    public void Peek_WhenStackIsEmpty_ShouldThrowInvalidOperationException()
    {
        // Arrange
        this._stack.Clear();
        
        // Act / Assert
        Assert.Throws<InvalidOperationException>(() => this._stack.Peek());
    }

    [Fact]
    public void Pop_ShouldGetLastItemAndRemoveIt()
    {
        // Arrange
        var expected = 99;
        
        // Act
        var actual = this._stack.Pop();
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.NotEqual(expected, this._stack.Peek());
    }
    
    [Fact]
    public void Pop_WhenStackIsEmpty_ShouldThrowInvalidOperationException()
    {
        // Arrange
        this._stack.Clear();
        
        // Act / Assert
        Assert.Throws<InvalidOperationException>(() => this._stack.Pop());
    }
    
    [Fact]
    public void Push_ShouldAddItemToTheHead()
    {
        // Arrange
        var expected = 1001;
        
        // Act
        this._stack.Push(expected);
        
        // Assert
        Assert.Equal(expected, this._stack.Pop());
    }

    [Fact]
    public void Clear_ShouldRemoveAllItemsFromStack()
    {
        // Act
        this._stack.Clear();

        // Assert
        Assert.Empty(this._stack);
    }
    
    [Fact]
    public void Clear_ShouldReleaseMemory()
    {
        // Arrange
        var stack = new Stack<byte[]>();
        var weakRefs = new System.Collections.Generic.List<WeakReference>();
        for (var i = 0; i < 100; i++)
        {
            var data = new byte[1000000];
            stack.Push(data);
            weakRefs.Add(new WeakReference(data));
        }
    
        // Act
        stack.Clear();
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
    [InlineData(100, false)]
    public void Contains_ShouldReturnCorrectly(int item, bool expected)
    {
        // Act
        var actual = this._stack.Contains(item);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Count_ShouldReturnCorrectly()
    {
        // Arrange
        var expected = 100;
        
        // Act
        var actual = this._stack.Count;
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Push_OneMillionItems_ShouldNotBreak()
    {
        // Arrange
        var expected = 1000000;
        this._stack.Clear();
        
        // Act
        for (int i = 0; i < expected; i++) 
            this._stack.Push(i);
        
        // Assert
        Assert.Equal(expected, this._stack.Count);
    }
    
    [Fact]
    public void Pop_HundredThousandItems_ShouldCompleteInUnder100Milliseconds()
    {
        // Arrange
        this._stack.Clear();
        for (var i = 0; i < 100000; i++) 
            this._stack.Push(i);
        
        // Act
        var stopwatch = Stopwatch.StartNew();
        while (this._stack.Count > 0) 
            this._stack.Pop();
        stopwatch.Stop();
        
        // Assert
        Assert.True(stopwatch.ElapsedMilliseconds < 100);
    }
}