
// Don't forget to put this at the top, so C# knows where to find the StreamWriter class


public class Writing 

{
    
    public string fileName = "myFile.txt";

    using (StreamWriter outputFile = new StreamWriter(filename))
{
    // You can add text to the file with the WriteLine method
    outputFile.WriteLine("This will be the first line in the file.");
    
    // You can use the $ and include variables just like with Console.WriteLine
    string color = "Blue";
    outputFile.WriteLine($"My favorite color is {color}");
}
}
