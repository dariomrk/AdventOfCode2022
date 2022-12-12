using static AOC.Data;

Queue<(string Opcode, int? Value)> INSTRUCTIONS = new();

foreach (var instruction in Raw.Split(Environment.NewLine))
{
    switch (instruction.Split(' ')[0])
    {
        case "addx":
            INSTRUCTIONS.Enqueue((instruction.Split(' ')[0], int.Parse(instruction.Split(' ')[1])));
            break;
        case "noop":
            INSTRUCTIONS.Enqueue((instruction.Split(' ')[0], null));
            break;
        default:
            throw new Exception();
    }
}

char[,] SCREEN = new char[6, 40];
int XPOS = 0;
int YPOS = 0;

int CYCL = 1;
int REGX = 1;

string OP;
int? VAL = null;

int HaltCycles = 0;

while (INSTRUCTIONS.Count > 0)
{
    if (HaltCycles == 0)
    {
        (OP, VAL) = INSTRUCTIONS.Dequeue()!;

        switch (OP)
        {
            case "addx":
                HaltCycles = 2;
                break;
            case "noop":
                HaltCycles = 1;
                break;
        }
    }
    HaltCycles--;

    if (HaltCycles == 0)
    {
        REGX += VAL ?? 0;
    }

    CYCL++;

    if (CYCL > 240)
    {
        break;
    }

    if (XPOS == REGX -1 || XPOS == REGX || XPOS == REGX+1)
    {
        SCREEN[YPOS, XPOS] = '#';
    }
    else
    {
        SCREEN[YPOS, XPOS] = '.';
    }

    XPOS++;
    if (CYCL % 40 == 0)
    {
        YPOS++;
        XPOS = 0;
    }
}

for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 40; j++)
    {
        Console.Write(SCREEN[i, j]);
    }
    Console.WriteLine();
}
