using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        //job1._name = "Freisi";
        job1._jobTitle = "Cybersecurity Analyst";
        //job1._jobTitle = "Developer";
        job1._company = "BBG";
        job1._startYear = 2023;
        job1._endYear = 2026;



        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;


        Resume myResume = new Resume();
        myResume._memberName = "Jorge";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        //job1.DisplayMember();
        myResume.Display();
    }
}