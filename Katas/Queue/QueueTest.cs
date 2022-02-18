using Queue.Models;
using Xunit;

namespace Queue;

public class QueueTest
{

    private SampleObject obj1 = new SampleObject();
    private SampleObject obj2 = new SampleObject();
    private SampleObject obj3 = new SampleObject();

    [Fact]
    public void WeShouldHaveQueue()
    {
        MyQueue<object> queue = new MyQueue<object>();
        queue.Enqueue(new { });
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void We_Create_Queue_And_Should_Be_Able_To_Return_First_Element_Of_Queue()
    {
        MyQueue<SampleObject> queue = new ();
      
        queue.Enqueue(obj1);
        var obj = queue.Dequeue();
      
        Assert.Equal(obj, obj1);
        Assert.Equal(0, queue.Count);
    }


    [Fact]
    public void We_Add_2_Items_And_Count_OF_Queue_Should_Be_2()
    {
        // Arrange 
        MyQueue<SampleObject> queue = new();
        
        // Act 
        queue.Enqueue(obj1);
        queue.Enqueue(obj2);

        // Assert 
        Assert.Equal(2, queue.Count);
    }


    [Fact]
    public void We_Add_3_Item_And_Should_Reterieve_Them_In_Same_Order()
    {
        // Arrange 
        MyQueue<SampleObject> queue = new();

        // Act 
        queue.Enqueue(obj1);
        queue.Enqueue(obj2);
        queue.Enqueue(obj3);


        // Act 
        queue.Enqueue(obj1);
        queue.Enqueue(obj2);
        queue.Enqueue(obj3);

        var obj_3 = queue.Dequeue();
        var obj_2 = queue.Dequeue();
        var obj_1 = queue.Dequeue();

        // Assert 
        Assert.Equal(obj_3.Id, obj3.Id);
        Assert.Equal(obj_2.Id, obj2.Id);
        Assert.Equal(obj_1.Id, obj1.Id);
    }

    [Fact]
    public void We_Should_Add_3_And_Peek_First_Item_Without_Removing_It_From_Queue()
    {
        // Arrange 
        MyQueue<SampleObject> queue = new();

        // Act 
        queue.Enqueue(obj1);
        queue.Enqueue(obj2);
        queue.Enqueue(obj3);

        var obj_3 = queue.Peek();

        // Assert 
        Assert.Equal(3, queue.Count);
        Assert.Equal(obj_3, obj3);
    }
}