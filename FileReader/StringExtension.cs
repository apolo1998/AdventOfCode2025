namespace FileReader;
public static class StringExtension
{
    public static int ToSignedInt(this string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            throw new ArgumentException("Input cannot be empty.");
        
        char direction = s[0];
        string s2 = s.Substring(1);
        int number = int.Parse(s2);
        if (direction == 'L')
        {
            number = -1 * int.Parse(s2);
        }

        return number;

    }
}