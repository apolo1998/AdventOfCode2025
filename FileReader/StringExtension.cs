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

    public static bool HasBetween(this string s, long number)
    {
        var lineSplit = s.Split('-');

        long start = Convert.ToInt64(lineSplit.ElementAt(0));
        long end = Convert.ToInt64(lineSplit.ElementAt(1));
        return number >= start && number <= end;
    }

    public static Tuple<long, long> SplitStringToTupel(this string s)
    {
        var lineSplit = s.Split('-');

        long start = Convert.ToInt64(lineSplit.ElementAt(0));
        long end = Convert.ToInt64(lineSplit.ElementAt(1));
        return new Tuple<long, long>(start, end);
    }
    public static bool InRange(this Tuple<long, long> s, long number)
    {
        if (number < s.Item1 || number > s.Item2)
            return false;
        return true;
    }
}