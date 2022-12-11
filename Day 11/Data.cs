using System.Numerics;

namespace AOC
{
    public static class Data
    {
        public static string Raw { get; } = @"Monkey 0:
  Starting items: 56, 56, 92, 65, 71, 61, 79
  Operation: new = old * 7
  Test: divisible by 3
    If true: throw to monkey 3
    If false: throw to monkey 7

Monkey 1:
  Starting items: 61, 85
  Operation: new = old + 5
  Test: divisible by 11
    If true: throw to monkey 6
    If false: throw to monkey 4

Monkey 2:
  Starting items: 54, 96, 82, 78, 69
  Operation: new = old * old
  Test: divisible by 7
    If true: throw to monkey 0
    If false: throw to monkey 7

Monkey 3:
  Starting items: 57, 59, 65, 95
  Operation: new = old + 4
  Test: divisible by 2
    If true: throw to monkey 5
    If false: throw to monkey 1

Monkey 4:
  Starting items: 62, 67, 80
  Operation: new = old * 17
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 6

Monkey 5:
  Starting items: 91
  Operation: new = old + 7
  Test: divisible by 5
    If true: throw to monkey 1
    If false: throw to monkey 4

Monkey 6:
  Starting items: 79, 83, 64, 52, 77, 56, 63, 92
  Operation: new = old + 6
  Test: divisible by 17
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 7:
  Starting items: 50, 97, 76, 96, 80, 56
  Operation: new = old + 3
  Test: divisible by 13
    If true: throw to monkey 3
    If false: throw to monkey 5";

        // 2Lazy?
        //public static List<Monkey> Monkeys = new()
        //{
        //    // Monkey 0
        //    new Monkey(new List<int>(){56, 56, 92, 65, 71, 61, 79},
        //        (old) => old * 7,
        //        (input) => input % 3 == 0,
        //        3,
        //        7
        //        ),
        //    // Monkey 1
        //    new Monkey(new List<int>(){61, 85},
        //        (old) => old + 5,
        //        (input) => input % 11 == 0,
        //        6,
        //        4
        //        ),
        //    // Monkey 2
        //    new Monkey(new List<int>(){54, 96, 82, 78, 69},
        //        (old) => old * old,
        //        (input) => input % 7 == 0,
        //        0,
        //        7
        //        ),
        //    // Monkey 3
        //    new Monkey(new List<int>(){57, 59, 65, 95},
        //        (old) => old + 4,
        //        (input) => input % 2 == 0,
        //        5,
        //        1
        //        ),
        //    // Monkey 4
        //    new Monkey(new List<int>(){62, 67, 80},
        //        (old) => old * 17,
        //        (input) => input % 19 == 0,
        //        2,
        //        6
        //        ),
        //    // Monkey 5
        //    new Monkey(new List<int>(){91},
        //        (old) => old + 7,
        //        (input) => input % 5 == 0,
        //        1,
        //        4
        //        ),
        //    // Monkey 6
        //    new Monkey(new List<int>(){79, 83, 64, 52, 77, 56, 63, 92},
        //        (old) => old + 6,
        //        (input) => input % 17 == 0,
        //        2,
        //        0
        //        ),
        //    // Monkey 7
        //    new Monkey(new List<int>(){50, 97, 76, 96, 80, 56},
        //        (old) => old + 3,
        //        (input) => input % 13 == 0,
        //        3,
        //        5
        //        ),
        //};
        public static List<Monkey> Monkeys = new()
        {
            // Monkey 0
            new Monkey(new List<ulong>(){56, 56, 92, 65, 71, 61, 79},
                (old) => old * 7,
                (input) => input % 3 == 0,
                3,
                7
                ),
            // Monkey 1
            new Monkey(new List<ulong>(){61, 85},
                (old) => old + 5,
                (input) => input % 11 == 0,
                6,
                4
                ),
            // Monkey 2
            new Monkey(new List<ulong>(){54, 96, 82, 78, 69},
                (old) => old * old,
                (input) => input % 7 == 0,
                0,
                7
                ),
            // Monkey 3
            new Monkey(new List<ulong>(){57, 59, 65, 95},
                (old) => old + 4,
                (input) => input % 2 == 0,
                5,
                1
                ),
            // Monkey 4
            new Monkey(new List<ulong>(){62, 67, 80},
                (old) => old * 17,
                (input) => input % 19 == 0,
                2,
                6
                ),
            // Monkey 5
            new Monkey(new List<ulong>(){91},
                (old) => old + 7,
                (input) => input % 5 == 0,
                1,
                4
                ),
            // Monkey 6
            new Monkey(new List<ulong>(){79, 83, 64, 52, 77, 56, 63, 92},
                (old) => old + 6,
                (input) => input % 17 == 0,
                2,
                0
                ),
            // Monkey 7
            new Monkey(new List<ulong>(){50, 97, 76, 96, 80, 56},
                (old) => old + 3,
                (input) => input % 13 == 0,
                3,
                5
                ),
        };
    }
}
