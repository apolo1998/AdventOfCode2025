using FileReader;

var file = FileReader.FileReader.ReadFile("C:\\SWK5\\Advent of Code\\Day1\\input.txt");
// var file = new List<string>();
// file.Add("L68"); // passes over 0
// file.Add("L30");
// file.Add("R48"); // reaches 0
// file.Add("L5");
// file.Add("R60"); // passes over 0
// file.Add("L55"); // reaches 0
// file.Add("L1");  
// file.Add("L99"); // reaches 0
// file.Add("R14");
// file.Add("L82"); // passes over 0

int pos = 50;
int zeroCount = 0;
foreach (var line in file)
{
    var converted = line.ToSignedInt();
    int passes = Math.Abs(converted) / 100; // number of full circles
    zeroCount += passes;
    converted %= 100;
    
    Console.WriteLine($"{pos} + {converted} = {pos+converted}");
    if (converted < 0 && pos < Math.Abs(converted) && pos != 0)
    {
        zeroCount++;
    }
    pos += converted;
    
    if (pos < 0)
    {
        pos = 100 + pos;
        continue;
    }
    if (pos > 100)
    {
        pos -= 100;
        zeroCount++;
        continue;
    }

    if (pos == 0 || pos == 100)
    {
        pos = 0;
        zeroCount++;
    }
}
Console.WriteLine("Final startingPoint "+zeroCount);
