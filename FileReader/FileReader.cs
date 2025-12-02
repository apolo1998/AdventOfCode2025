namespace FileReader;

public static class FileReader
{
    public static string ReadFile(string path)
    {
        return File.ReadAllText(path);

    }
}