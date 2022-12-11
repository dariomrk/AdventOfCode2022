using static AOC.Data;

for (int round = 0; round < 10000; round++)
{
    Console.WriteLine(round);
    foreach (Monkey m in Monkeys)
    {
        while (m.ContainsItems)
        {
            var output = m.NextItem();

            Monkeys[output.MonkeyIndex].AddItem(output.Item);
        }
    }
}

Monkeys.Sort((x, y) => y.Count.CompareTo(x.Count));

Console.WriteLine(Monkeys[0].Count * Monkeys[1].Count);
Console.ReadKey();

// Delegate definitions
// eg. new = old * 5
public delegate ulong Operation(ulong input);
// eg. divisible by 17
public delegate bool Test(ulong input);

public class Monkey
{
    readonly Queue<ulong> _items;
    Operation _operation;
    Test _test;
    int _trueTarget;
    int _falseTarget;
    ulong _count = 0;

    public ulong Count { get => _count; }
    public bool ContainsItems { get => _items.Any(); }

    public Monkey(List<ulong> startingItems, Operation operation, Test test, int trueTarget, int falseTarget)
    {
        _items = new(startingItems);
        _operation = operation;
        _test = test;
        _trueTarget = trueTarget;
        _falseTarget = falseTarget;
    }

    public (int MonkeyIndex, ulong Item) NextItem()
    {
        ulong item = _items.Dequeue();
        int monkeyIndex;

        item = _operation(item);
        item %= 9699690; // GCM of divisibility tests

        if (_test(item))
        {
            monkeyIndex = _trueTarget;
        }
        else
        {
            monkeyIndex = _falseTarget;
        }

        _count++;

        return (monkeyIndex, item);
    }
    public void AddItem(ulong item)
    {
        _items.Enqueue(item);
    }

}