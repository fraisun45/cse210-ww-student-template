using System;
class Resume
{
    public string _memberName;
    public List<Job>_jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_memberName} ");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}