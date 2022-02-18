using System;

namespace Queue.Models;

public class SampleObject
{
    public SampleObject()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}