using static AOC.Data;

var map = ParseMap();
int minDistance = int.MaxValue;
foreach (var startingPoint in ValidStartingPoints)
{
    int distance = GetDistance(map, startingPoint, End);
    Console.WriteLine(distance);

    if(distance == -1)
        continue;

    minDistance = distance < minDistance ? distance : minDistance;
}
Console.WriteLine(minDistance);

int GetDistance((int Height, int X, int Y)[,] map, (int Height, int X, int Y) start, (int Height, int X, int Y) end)
{
    HashSet<(int X, int Y)> visited = new();
    Queue<(int Height, int X, int Y, int Distance, bool Visited)> queue = new();

    queue.Enqueue((start.Height, start.X, start.Y, 0, false));

    while (queue.Any())
    {
        var current = queue.Dequeue();

        if (current.X == end.X && current.Y == end.Y)
            return current.Distance;

        if (visited.Contains((current.X, current.Y)))
            continue;
        visited.Add((current.X, current.Y));

        foreach (var adjacent in GetAdjacent((current.Height, current.X, current.Y), map))
        {
            queue.Enqueue((adjacent.Height, adjacent.X, adjacent.Y, current.Distance +1,false));
        }
    }
    return -1;
}

(int Height, int X, int Y)[] GetAdjacent((int Height, int X, int Y) position, (int Height, int X, int Y)[,] map)
{
    List<(int Height, int X, int Y)> adjacent = new();

    foreach (var offset in new (int X, int Y)[] { (1, 0), (-1, 0), (0, 1), (0, -1) }) // R L U D
    {
        if (0 <= position.X + offset.X
            && position.X + offset.X < MapXLength // prevent IndexOutOfRange

            && 0 <= position.Y + offset.Y
            && position.Y + offset.Y < MapYLength // prevent IndexOutOfRange

            && (map[position.X + offset.X, position.Y + offset.Y].Height
            - map[position.X, position.Y].Height)
            <= 1) // max height delta 1
        {
            adjacent.Add(map[position.X + offset.X, position.Y + offset.Y]);
        }
    }
    return adjacent.ToArray();
}
