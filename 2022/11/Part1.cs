using static AOC.Data;

for (int round = 0; round < 20; round++)
{
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

// Delegate definitions
// eg. new = old * 5
public delegate int Operation(int input);
// eg. divisible by 17
public delegate bool Test(int input);

public class Monkey
{
    readonly Queue<int> _items;
    Operation _operation;
    Test _test;
    int _trueTarget;
    int _falseTarget;
    int _count = 0;

    public int Count { get => _count; }
    public bool ContainsItems { get => _items.Any(); }

    public Monkey(List<int> startingItems, Operation operation, Test test, int trueTarget, int falseTarget)
    {
        _items = new(startingItems);
        _operation = operation;
        _test = test;
        _trueTarget = trueTarget;
        _falseTarget = falseTarget;
    }

    public (int MonkeyIndex, int Item) NextItem()
    {
        int item = _items.Dequeue();
        int monkeyIndex;

        item = _operation(item);

        item /= 3;

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
    public void AddItem(int item)
    {
        _items.Enqueue(item);
    }

}