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
        var newElements = new T[elements.Length + 1];

        for (int i = 0; i < elements.Length; i++)
        {
            newElements[i] = elements[i];
        }

        newElements[elements.Length] = obj1;

        elements = newElements;
    }

    public T Pop()
    {
        CheckIfIsEmpty();

        var item = elements[elements.Length - 1];

        var newElements = new T[elements.Length - 1];

        for (int i = 0; i < elements.Length - 1; i++)
        {
            newElements[i] = elements[i];
        }

        elements = newElements;

        return item;
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