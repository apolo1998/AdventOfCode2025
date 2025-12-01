namespace FileReader;

public static class FileReader
{
    public static IEnumerable<string> ReadFile(string path)
    {
        var lines = new List<string>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(path);
            //Read the first line of text
            string line =sr.ReadLine()!;
            //Continue to read until you reach end of file
            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }

        return lines;

    }
}