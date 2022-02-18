namespace Stack;

internal class MyStack<T>
{
    public MyStack()
    {
        elements = new T[0];
    }

    public int Count => elements.Length;

    public T[] elements;

    public void Push(T obj1)
    {
        CreateAscendingArray();
        elements[elements.Length - 1] = obj1;
    }

    public T Pop()
    {
        CheckIfIsEmpty();
        var item = elements[elements.Length - 1];
        CreateDescendingArray();
        return item;
    }

    private void CreateDescendingArray()
    {
        var count = this.elements.Length - 1;
        var counter = 0;

        var newArray = new T[count];

        while (counter < count)
        {
            newArray[counter] = this.elements[counter]; ;
            counter++;
        }

        this.elements = newArray;
    }

    private void CreateAscendingArray()
    {
        var count = this.elements.Length + 1;
        var newArray = new T[count];
        var counter = 0;

        if (count == 1)
        {
            this.elements = new T[count];
            return;
        }

        while (counter <= this.elements.Length - 1)
        {
            newArray[counter] = this.elements[counter];
            counter++;
        }

        this.elements = newArray;
    }

    public T Peek()
    {
        CheckIfIsEmpty();
        return this.elements[elements.Length - 1];
    }

    private void CheckIfIsEmpty()
    {
        if (elements.Length - 1 < 0)
            throw new System.Exception("The stack is empty.");
    }
}