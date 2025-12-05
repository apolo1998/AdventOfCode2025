

using FileReader;

var file = File.ReadAllText("C:\\SWK5\\Advent of Code\\Day5\\input.txt");
//var file = "3-5\n10-14\n16-20\n12-18\n1\n5\n8\n11\n17\n32";
List<string> content = file.Split('\n').ToList();
var freshList = new List<string>();
var current = new List<long>();
// expand liens
foreach (var line in content)
{ 
    if(String.IsNullOrEmpty(line))
        continue;
    if (line.Contains('-'))
    {
        freshList.Add(line);
    }
    else
    {
        current.Add(Convert.ToInt64(line));
    }
}
var isFresh = new List<long>();

foreach (var line in freshList)
{
    foreach (var num in current)
    {
        if (line.HasBetween(num))
        {
            isFresh.Add(num);
        }
    }
}

var result = isFresh.GroupBy<long, object>(test => test)
    .Select(grp => grp.First())
    .ToList();



Console.WriteLine(result.Count);