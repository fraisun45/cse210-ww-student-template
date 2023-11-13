public class Job
{
    public string _jobTitle;
    //public string _name;
    public List<string> _jobs;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} {_company} {_jobs} {_startYear}-{_endYear}");
    }
}

