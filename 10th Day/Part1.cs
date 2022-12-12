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

int SUM = 0;

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

    switch (CYCL)
    {
        case 20:
            SUM += CYCL * REGX;
            break;
        case 60:
            SUM += CYCL * REGX;
            break;
        case 100:
            SUM += CYCL * REGX;
            break;
        case 140:
            SUM += CYCL * REGX;
            break;
        case 180:
            SUM += CYCL * REGX;
            break;
        case 220:
            SUM += CYCL * REGX;
            break;
    }
}
Console.WriteLine(SUM);
