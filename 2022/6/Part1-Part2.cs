using static aoc.Data;

var part1 = 4;
for (int i = 0; i < data.Length - part1; i++)
{
    if (data.Substring(i, part1).ToCharArray().Distinct().Count() == part1)
    {
        Console.WriteLine($"{i+part1}");
        break;
    }

}

var part2 = 14;
for (int i = 0; i < data.Length - part2; i++)
{
    if (data.Substring(i,part2).ToCharArray().Distinct().Count() == part2)
        Console.WriteLine($"{i+part2}"); 
}
