using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        Console.ReadLine();

        //Console.Clear();

        Console.WriteLine("You got it");

        Reader readingClass = new Reader();
        readingClass.ReadFile();

    }
}