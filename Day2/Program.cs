

var file = FileReader.FileReader.ReadFile("C:\\SWK5\\Advent of Code\\Day2\\input.txt");
//var file = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
//var file = "95-115";

List<string> content = file.Split(',').ToList();
var result = new List<string>();
// expand liens
foreach (var line in content)
{
    var lineSplit = line.Split('-');

    long start = Convert.ToInt64(lineSplit.ElementAt(0));
    long end = Convert.ToInt64(lineSplit.ElementAt(1));
    for (long i = start; i <= end; i++)
    {
        result.Add(i.ToString());
    }
}

long illegalNumbers = 0;
foreach (var line in result)
{
    int splitter = line.Length / 2;
    
    while (splitter >= 1)
    {
        if(line.Length%splitter == 0)
        {
            bool isIllegal = false;
            var splitInEqualParts = Split(line, splitter);
            var areEqual = splitInEqualParts.Distinct().Count() == 1;
            if (areEqual)
            {
                Console.WriteLine("Number is illegal " + line);
                illegalNumbers+= Convert.ToInt64(line);
                break;
            }
        } 
        splitter--;
    }
}
Console.WriteLine(illegalNumbers);

static IEnumerable<string> Split(string str, int chunkSize)
{
    return Enumerable.Range(0, str.Length / chunkSize)
        .Select(i => str.Substring(i * chunkSize, chunkSize));
}
