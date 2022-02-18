using System;

namespace Stack.Models;


public class SampleObject
{
    public SampleObject()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
