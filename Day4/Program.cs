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
//var file = "99";
List<string> content = file.Split('\n').ToList();
int rows = content.Count;
int cols = content.Max(l => l.Length);

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
for (int r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        char center = matrix[r, c];
        if (center != '@')
            continue;
        if (lessThan4PaperRoll(r,c, rows,cols))
        {
            sum++;
        }
    }
}
Console.WriteLine(sum);

bool lessThan4PaperRoll(int row, int col, int rows, int cols)
{
    int paper = 0;

    void check(int r, int c)
    {
        if (r >= 0 && r < rows && c >= 0 && c < cols)
            paper += matrix[r, c] == '@' ? 1 : 0;
    }

    check(row + 1, col + 1);
    check(row + 1, col);
    check(row + 1, col - 1);
    check(row - 1, col + 1);
    check(row - 1, col);
    check(row - 1, col - 1);
    check(row, col + 1);
    check(row, col - 1);

    return paper < 4;
}

