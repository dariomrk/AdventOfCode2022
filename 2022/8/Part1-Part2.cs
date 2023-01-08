using static aoc.Data;
using static System.Console;

List<int[]> grid = new();

foreach (var row in Rows)
{
    grid.Add(Array.ConvertAll(row.ToCharArray(), x => (int)char.GetNumericValue(x)));
}

int visible = 0;

for (int rowI = 0; rowI<grid.Count; rowI++)
{

    for (int colI = 0; colI<grid[rowI].Length; colI++)
    {
        if (DetermineVisibility(rowI, colI, grid))
            visible++;
    }

}

WriteLine(visible);

static bool DetermineVisibility(int r, int c, List<int[]> grid)
{
    int height = grid[r][c];

    return VisibleUp(grid, height, r, c) ||
        VisibleDown(grid, height, r, c) ||
        VisibleLeft(grid, height, r, c) ||
        VisibleRight(grid, height, r, c);
}

static bool VisibleUp(List<int[]> grid, int height, int r, int c)
{
    for (int i = (r-1); i >= 0; i--)
    {
        if (height <= grid[i][c])
        {
            return false;
        }
    }
    return true;
}

static bool VisibleDown(List<int[]> grid, int height, int r, int c)
{
    for (int i = (r+1); i < grid.Count; i++)
    {
        if (height <= grid[i][c])
        {
            return false;
        }
    }
    return true;
}

static bool VisibleLeft(List<int[]> grid, int height, int r, int c)
{
    for (int i = (c-1); i >= 0; i--)
    {
        if (height <= grid[r][i])
        {
            return false;
        }
    }
    return true;
}

static bool VisibleRight(List<int[]> grid, int height, int r, int c)
{
    for (int i = (c+1); i < grid.Count; i++)
    {
        if (height <= grid[r][i])
        {
            return false;
        }
    }
    return true;
}

double maxScenicScore = 0;
for (int i = 1; i < grid.Count -1; i++)
{
    for (int j = 1; j < grid.Count -1; j++)
    {
        if (DetermineScenicScore(i, j, grid) > maxScenicScore)
        {
            maxScenicScore = DetermineScenicScore(i, j, grid);
        }
    }
}

WriteLine(maxScenicScore);

static double DetermineScenicScore(int r, int c, List<int[]> grid)
{
    int height = grid[r][c];

    return ScoreUp(grid, height, r, c) *
        ScoreDown(grid, height, r, c) *
        ScoreLeft(grid, height, r, c) *
        ScoreRight(grid, height, r, c);
}

static double ScoreUp(List<int[]> grid, int height, int r, int c)
{
    double score = 0;
    for (int i = (r-1); i >= 0; i--)
    {
        if (height <= grid[i][c])
        {
            score++;
            break;
        }
        score++;
    }
    return score;
}

static double ScoreDown(List<int[]> grid, int height, int r, int c)
{
    double score = 0;
    for (int i = (r+1); i < grid.Count; i++)
    {
        if (height <= grid[i][c])
        {
            score++;
            break;
        }
        score++;
    }
    return score;
}

static double ScoreLeft(List<int[]> grid, int height, int r, int c)
{
    double score = 0;

    for (int i = (c-1); i >= 0; i--)
    {
        if (height <= grid[r][i])
        {
            score++;
            break;
        }
        score++;
    }
    return score;
}

static double ScoreRight(List<int[]> grid, int height, int r, int c)
{
    double score = 0;
    for (int i = (c+1); i < grid.Count; i++)
    {
        if (height <= grid[r][i])
        {
            score++;
            break;
        }
        score++;
    }
    return score;
}
