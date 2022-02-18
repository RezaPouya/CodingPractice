namespace Queue;

public class MyQueue<T>
{
    public MyQueue()
    {
        this.Items = new T[0];
    }

    public int Count { get; private set; }

    private T[] Items;

    public void Enqueue(T p)
    {
        CreateAscendingArray();
        this.Items[Count] = p;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
            return default;

        var item = this.Items[Count - 1];

        CreateDescendingArray();
        this.Count--;

        return item;
    }

    public T Peek()
    {
        return this.Items[Count - 1];
    }

    private void CreateDescendingArray()
    {
        var count = this.Count - 1;
        var counter = 0;

        var newArray = new T[count];

        while (counter < count)
        {
            newArray[counter] = this.Items[counter]; ;
            counter++;
        }

        this.Items = newArray;
    }

    private void CreateAscendingArray()
    {
        var count = this.Count + 1;

        if (count == 1)
        {
            this.Items = new T[count];
            return;
        }

        var counter = 0;

        var newArray = new T[count];

        while (counter <= count - 2)
        {
            newArray[counter] = this.Items[counter]; ;
            counter++;
        }

        this.Items = newArray;
    }
}