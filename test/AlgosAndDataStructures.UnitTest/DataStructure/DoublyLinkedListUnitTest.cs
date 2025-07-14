using AlgosAndDataStructures.DataStructures;
using Xunit;

namespace AlgosAndDataStructures.UnitTest.DataStructure;

public class DoublyLinkedListUnitTest
{
    private DoublyLinkedList<int> _doublyLinkedList;

    public DoublyLinkedListUnitTest()
    {
        this._doublyLinkedList = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];
    }
    
    [Fact]
    public void IsReadonly_ShouldReturnFalse()
    {
        // Act / Assert
        Assert.False(this._doublyLinkedList.IsReadOnly);
    }
    
    [Fact]
    public void AddHead_ShouldAddItemToTheHead()
    {
        // Arrange
        var expected = 1;
        
        // Act
        this._doublyLinkedList.AddHead(expected);
        
        // Assert
        Assert.Equal(this._doublyLinkedList.Head, expected);
    }

    [Fact]
    public void AddTail_ShouldAddItemToTheTail()
    {
        // Arrange
        var expected = 110;
        
        // Act
        this._doublyLinkedList.AddTail(expected);
        
        // Assert
        Assert.Equal(this._doublyLinkedList.Tail, expected);
    }
    
    [Fact]
    public void AddTail_ShouldAddItemToTheTailWhenListIsEmpty()
    {
        // Arrange
        var expected = 5;
        this._doublyLinkedList.Clear();
        this._doublyLinkedList.AddTail(expected);
        
        // Act
        this._doublyLinkedList.AddTail(expected);
        
        // Assert
        Assert.Equal(this._doublyLinkedList.Head, expected);
        Assert.Equal(this._doublyLinkedList.Tail, expected);
    }
    
    [Fact]
    public void Add_ShouldAddItemToTheHead()
    {
        // Arrange
        var expected = 5;
        
        // Act
        this._doublyLinkedList.AddHead(expected);
        
        // Assert
        Assert.Equal(this._doublyLinkedList.Head, expected);
    }

    [Fact]
    public void Clear_ShouldRemoveAllItemsFromList()
    {
        // Act
        this._doublyLinkedList.Clear();

        // Assert
        Assert.Empty(this._doublyLinkedList);
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
        var actual = this._doublyLinkedList.Contains(item);
        
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
        this._doublyLinkedList.CopyTo(actual, 0);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CopyTo_WhenIndexIsOne_ShouldReturnCorrectly()
    {
        // Arrange
        int[] actual = new int[11];
        
        // Act
        this._doublyLinkedList.CopyTo(actual, 1);
        
        // Assert
        Assert.Equal(0, actual[0]);
        Assert.Equal(10, actual[10]);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(30)]
    [InlineData(100)]
    public void Remove_ShouldRemoveItem(int item)
    {
        // Act
        this._doublyLinkedList.Remove(item);
        
        // Assert
        Assert.DoesNotContain(item, this._doublyLinkedList);
    }
    
    [Fact]
    public void Remove_ShouldReturnFalseWhenListIsEmpty()
    {
        // Arrange
        this._doublyLinkedList = [];
        
        // Act
        var actual = this._doublyLinkedList.Remove(5);
        
        // Assert
        Assert.False(actual);
    }
}