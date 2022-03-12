namespace Queue;

public class MyQueue<T>
{
    public MyQueue()
    {
        this.Items = new T[0];
    }

    public int Count => this.Items.Length;

    private T[] Items;

    public void Enqueue(T p)
    {
        var newElements = new T[Count + 1];

        if (Count > 0)
        {
            for (int i = 0; i < Count; i++)
            {
                newElements[i] = Items[i];
            }
        }

        newElements[Count] = p;
        Items = newElements;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
            return default;

        var item = this.Items[Count - 1];

        var newElements = new T[Count - 1];

        for (int i = 0; i < Count - 1; i++)
        {
            newElements[i] = Items[i];
        }

        Items = newElements;

        return item;
    }

    public T Peek()
    {
        return this.Items[Count - 1];
    }
}