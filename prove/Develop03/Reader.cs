public class Reader
{
    
    string currentDirectory; 
    string line;

    public void ReadFile()

    {
        // Get the current directory of the program
        currentDirectory = Directory.GetCurrentDirectory();

        string filePath = Path.Combine(currentDirectory, "books\\scriptures.txt");
       // Pass the file path to the StreamReader constructor
        StreamReader sFile = new StreamReader(filePath);

        line = sFile.ReadLine();

         // Continue to read until you reach end of file
        while (line != null)
        {
        // Write the line to console window
            Console.WriteLine(line);

        // Read the next line
            line = sFile.ReadLine();
        }

    // Close the file
        sFile.Close();
    }
    
    
}