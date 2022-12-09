using static AOC.Data;

int VISITED = 0;
int[,] GRID = new int[2000, 2000]; // 0 -> unvisited // 1 -> visited
Position HEAD = new Position() { X = 1000, Y = 1000 };
Position TAIL = new Position() { X = 1000, Y = 1000 };
GRID[1000, 1000] = 1;

Position DetermineNewTailPosition(Position head, Position tail)
{
    int deltaX = head.X - tail.X;
    int deltaY = head.Y - tail.Y;

    Position newPos = new Position() { X = tail.X, Y = tail.Y };

    if (Math.Abs(deltaX) > 1 || Math.Abs(deltaY) > 1)
    {
        newPos.X += Math.Sign(deltaX);
        newPos.Y += Math.Sign(deltaY);
    }
    return newPos;
}

void Traverse(string move)
{
    for (int i = 0; i < int.Parse(move.Split(' ')[1]); i++)
    {
        switch (move[0])
        {
            case 'U':
                HEAD.Y++;
                break;
            case 'D':
                HEAD.Y--;
                break;
            case 'L':
                HEAD.X--;
                break;
            case 'R':
                HEAD.X++;
                break;
            default:
                throw new Exception();
        }

        TAIL = DetermineNewTailPosition(HEAD, TAIL);

        GRID[TAIL.X, TAIL.Y] = 1;
    }
}

foreach (string line in Raw.Split(Environment.NewLine))
{
    Traverse(line);
}

// count visits
for (int i = 0; i < 2000; i++)
{
    for (int j = 0; j < 2000; j++)
    {
        if (GRID[i, j] == 1)
            VISITED++;
    }
}

Console.WriteLine(VISITED);

struct Position
{
    public int X;
    public int Y;
}
