

using FileReader;

var file = File.ReadAllText("C:\\SWK5\\Advent of Code\\Day5\\input.txt");
// var file = 
//     "3-5\n" +
//     "10-14\n" +
//     "16-20\n" +
//     "12-18\n";
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

//***************************************************************************************

var tupels = new List<Tuple<long, long>>();
foreach (var item in freshList)
{
    tupels.Add(item.SplitStringToTupel());
}
var sorted = tupels
    .OrderBy(tuple => tuple.Item1)
    .ThenBy(tuple => tuple.Item2)
    .ToList();
// combine tupels
var merged = new List<Tuple<long, long>>();

var currentTuple = sorted[0];

for (int i = 1; i < sorted.Count; i++)
{
    var next = sorted[i];

    // If next overlaps or is adjacent
    if (next.Item1 <= currentTuple.Item2)
    {
        // Extend current
        currentTuple = new Tuple<long,long>(currentTuple.Item1, Math.Max(currentTuple.Item2, next.Item2));
    }
    else
    {
        // Save completed interval
        merged.Add(currentTuple);
        currentTuple = next;
    }
}

// Add last interval
merged.Add(currentTuple);
long sum = 0;
foreach (var item in merged)
{
    long temp = item.Item2 - item.Item1 +1;

    Console.WriteLine(item+ " "+ temp);

    sum += temp;
}
Console.WriteLine(sum);