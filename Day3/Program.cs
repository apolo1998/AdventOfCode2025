

var file = File.ReadAllText("C:\\SWK5\\Advent of Code\\Day3\\input.txt");
// var file =
//     "987654321111111\n" +
//     "811111111111119\n" +
//     "234234234234278\n" +
//     "818181911112111";

//var file = "99";

List<string> content = file.Split('\n').ToList();
int totalBattery = 0;
int lineIt = 0;


foreach (var line in content)
{
    // 1. max char index excluding last char
    int firstIndex =
        line
            .Take(line.Length - 1)
            .Select((c, i) => new { c, i })
            .OrderByDescending(x => x.c)
            .First()
            .i;

    // 2. max char index from (firstIndex+1) to end
    int secondIndex =
        line
            .Skip(firstIndex + 1)
            .Select((c, offset) => new { c, idx = firstIndex + 1 + offset })
            .OrderByDescending(x => x.c)
            .First()
            .idx;
    totalBattery += ToInt(line.ElementAt(firstIndex)) * 10 + ToInt(line.ElementAt(secondIndex));
    Console.WriteLine( ToInt( line.ElementAt(firstIndex) ) *10 + ToInt( line.ElementAt(secondIndex) ) );
}
Console.WriteLine(totalBattery);
static int ToInt(char c)
{
    return c - '0';
}

int BestTwoDigitValueLinq(string s) =>
    Enumerable.Range(0, s.Length - 1)
        .SelectMany(i => Enumerable.Range(i + 1, s.Length - (i + 1))
            .Select(j => (s[i] - '0') * 10 + (s[j] - '0')))
        .Max();

var banks = new[] {
    "987654321111111",
    "811111111111119",
    "234234234234278",
    "818181911112111"
};

int total = content.Select(BestTwoDigitValueLinq).Sum();
Console.WriteLine(total); // 357


// foreach (var line in content)
// {
//     
//     int indexOfHighestNumber = IndexOfHighestNumberInString(line, 0, line.Length-1);
// Console.WriteLine("--------------------------------------------------------");
//     int indexOfSecondNumber = IndexOfHighestNumberInString(line, indexOfHighestNumber+1, line.Length);
//     
//     int battery = ToInt(line.ElementAt(indexOfHighestNumber)) * 10 + ToInt(line.ElementAt(indexOfSecondNumber));
//     
//     Console.WriteLine(lineIt+": " +battery);
//     totalBattery += battery;
//     lineIt++;
// }
// Console.WriteLine(totalBattery);

// int IndexOfHighestNumberInString(string line, int posToStart, int posToStop)
// {
//     int indexOfHighestNumber = posToStart;
//     int highestNumber = -1;
//    
//     for (int i = posToStart; i < posToStop; i++)
//     {
//         int digit = ToInt(line[i]);
//         Console.WriteLine(digit);
//         if (digit > highestNumber)
//         {
//             highestNumber = digit;
//             indexOfHighestNumber = i;
//         }
//     }
//     return indexOfHighestNumber;
// }
