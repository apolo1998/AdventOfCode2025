// var file =
//     "..@@.@@@@.\n" +
//     "@@@.@.@.@@\n" +
//     "@@@@@.@.@@\n" +
//     "@.@@@@..@.\n" +
//     "@@.@@@@.@@\n" +
//     ".@@@@@@@.@\n" +
//     ".@.@.@.@@@\n" +
//     "@.@@@.@@@@\n" +
//     ".@@@@@@@@.\n" +
//     "@.@.@@@.@.";
var file = File.ReadAllText("C:\\SWK5\\Advent of Code\\Day4\\input.txt");

List<string> content = file.Split('\n').ToList();
int rows = content.Count;
int cols = content.Max(l => l.Length);
List<Tuple<int,int>> toRemove= new List<Tuple<int, int>>();
char[,] matrix = new char[rows, cols];

for (int r = 0; r < rows; r++)
{
    var line = content[r];
    for (int c = 0; c < line.Length; c++)
    {
        matrix[r, c] = line[c];
    }
}

int sum = 0;
bool itemsToRemove = true;
while (itemsToRemove)
{
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            char center = matrix[r, c];
            if (center != '@')
                continue;
            LessThan4PaperRoll(r, c);
        
        }
    }

    itemsToRemove = RemoveRolls();
}


for (int r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        Console.Write(" "+matrix[r, c] +" ");
        sum += matrix[r, c] == 'X' ? 1 : 0;
    }
    Console.WriteLine();
}

Console.WriteLine(sum);
bool RemoveRolls()
{
    bool hasItems = toRemove.Count > 0;
    foreach (var t in toRemove)
    {
        matrix[t.Item1, t.Item2] = 'X';
    }
    toRemove.Clear();
    return hasItems;
}
void LessThan4PaperRoll(int row, int col)
{
    int paper = 0;

    void Check(int r, int c)
    {
        if (r >= 0 && r < rows && c >= 0 && c < cols)
            if (matrix[r, c] == '@')
            {
                paper++;
            }
    }
    void ToRemove(int r, int c)
    {
        if (matrix[r, c] == '@')
        {
            var tuple = new Tuple<int, int>(r, c);
            toRemove.Add(tuple);
        }
    }

    Check(row + 1, col + 1);
    Check(row + 1, col);
    Check(row + 1, col - 1);
    Check(row - 1, col + 1);
    Check(row - 1, col);
    Check(row - 1, col - 1);
    Check(row, col + 1);
    Check(row, col - 1);
    bool lessThan4Neighbours = paper < 4;
    
    if (lessThan4Neighbours)
    {
        Console.WriteLine($"Remove paper at row {row} col {col}");
        ToRemove(row, col);
    }
}

