using Xunit;

namespace AlgosAndDataStructures.UnitTest;

public class LinkedListUnitTest
{
    private LinkedList<int> _linkedList;

    public LinkedListUnitTest()
    {
        this._linkedList = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];
    }
    
    [Fact]
    public void AddHead_ShouldAddItemToTheHead()
    {
        // Arrange
        var expected = 1;
        
        // Act
        this._linkedList.AddHead(expected);
        
        // Assert
        Assert.Equal(this._linkedList.Head, expected);
    }

    [Fact]
    public void AddTail_ShouldAddItemToTheTail()
    {
        // Arrange
        var expected = 110;
        
        // Act
        this._linkedList.AddTail(expected);
        
        // Assert
        Assert.Equal(this._linkedList.Tail, expected);
    }
    
    [Fact]
    public void Add_ShouldAddItemToTheHead()
    {
        // Arrange
        var expected = 5;
        
        // Act
        this._linkedList.AddHead(expected);
        
        // Assert
        Assert.Equal(this._linkedList.Head, expected);
    }

    [Fact]
    public void Clear_ShouldRemoveAllItemsFromList()
    {
        // Act
        this._linkedList.Clear();

        // Assert
        Assert.Empty(this._linkedList);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(10, true)]
    [InlineData(40, true)]
    [InlineData(80, true)]
    [InlineData(100, true)]
    public void Contains_ShouldReturnCorrectly(int item, bool expected)
    {
        // Act
        var actual = this._linkedList.Contains(item);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CopyTo_WhenIndexIsZero_ShouldReturnCorrectly()
    {
        // Arrange
        int[] actual = new int[10];
        int[] expected = [100, 90, 80, 70, 60, 50, 40, 30, 20, 10];
        
        // Act
        this._linkedList.CopyTo(actual, 0);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CopyTo_WhenIndexIsOne_ShouldReturnCorrectly()
    {
        // Arrange
        int[] actual = new int[11];
        
        // Act
        this._linkedList.CopyTo(actual, 1);
        
        // Assert
        Assert.Equal(0, actual[0]);
        Assert.Equal(10, actual[10]);
    }
    
    [Fact]
    public void RemoveHead_ShouldRemoveItemFromTheHead()
    {
        // Arrange 
        var oldHead = this._linkedList.Head;
        
        // Act
        this._linkedList.RemoveHead();
        
        // Assert
        Assert.NotEqual(this._linkedList.Head, oldHead);
    }
    
    [Fact]
    public void RemoveHead_ShouldReturnTrueIfItemIsNull()
    {
        // Arrange
        this._linkedList = [];
        
        // Act
        var actual = this._linkedList.RemoveHead();
        
        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void RemoveTail_ShouldRemoveItemFromTheTail()
    {
        // Arrange
        var oldTail = this._linkedList.Tail;
        
        // Act
        this._linkedList.RemoveTail();
        
        // Assert
        Assert.NotEqual(this._linkedList.Tail, oldTail);
    }

    [Fact]
    public void RemoveTail_ShouldReturnTrueIfItemIsNull()
    {
        // Arrange
        this._linkedList = [];
        
        // Act
        var actual = this._linkedList.RemoveTail();
        
        // Assert
        Assert.True(actual);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(30)]
    [InlineData(100)]
    public void Remove_ShouldRemoveItem(int item)
    {
        // Act
        this._linkedList.Remove(item);
        
        // Assert
        Assert.DoesNotContain(item, this._linkedList);
    }
}