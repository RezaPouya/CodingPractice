using Stack.Models;
using System;
using Xunit;

namespace Stack;

public class StackTest
{
    private SampleObject obj1 = new SampleObject();
    private SampleObject obj2 = new SampleObject();
    private SampleObject obj3 = new SampleObject();

    [Fact]
    public void We_Should_Be_Able_To_Push_Item_To_Stack()
    {
        MyStack<SampleObject> stack = new MyStack<SampleObject>();

        Assert.Equal(0, stack.Count);

        stack.Push(obj1);

        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void We_Should_Be_Able_To_Push_Item_To_Stack_And_Pop_It()
    {
        MyStack<SampleObject> stack = new MyStack<SampleObject>();
        stack.Push(obj1);
        var item = stack.Pop();
        Assert.Equal(0, stack.Count);
        Assert.Equal(item.Id, obj1.Id);
    }

    [Fact]
    public void We_Should_Be_Able_To_Push_2_Item_To_Stack_And_Pop_1_And_Have_1_Item_In_Stack()
    {
        MyStack<SampleObject> stack = new MyStack<SampleObject>();
        stack.Push(obj1);
        stack.Push(obj2);
        var item = stack.Pop();
        Assert.Equal(1, stack.Count);
        Assert.Equal(item.Id, obj2.Id);
    }

    [Fact]
    public void We_Should_Be_Able_To_Push_2_Item_To_Stack_And_Pop_2_In_Same_Order()
    {
        MyStack<SampleObject> stack = new MyStack<SampleObject>();
        stack.Push(obj1);
        stack.Push(obj2);
        var item2 = stack.Pop();
        var item1 = stack.Pop();
        Assert.Equal(0, stack.Count);
        Assert.Equal(item2.Id, obj2.Id);
        Assert.Equal(item1.Id, obj1.Id);
    }

    [Fact]
    public void We_Should_Be_Able_To_Push_3_Item_To_Stack_And_Pop_1_And_Peek_1_For_2_times()
    {
        MyStack<SampleObject> stack = new MyStack<SampleObject>();

        stack.Push(obj1);
        stack.Push(obj2);
        stack.Push(obj3);

        var item3 = stack.Pop();

        var item2_peek = stack.Peek();

        Assert.Equal(2, stack.Count);

        Assert.Equal(item2_peek.Id, obj2.Id);
    }

    [Fact]
    public void We_Should_Throw_Exception_If_We_Want_Pop_From_Empty_Stack()
    {
        MyStack<SampleObject> stack = new MyStack<SampleObject>();

        Action act = () => stack.Pop();

        Exception exception = Assert.Throws<Exception>(act);

        Assert.Equal("The stack is empty.", exception.Message);
    }
}