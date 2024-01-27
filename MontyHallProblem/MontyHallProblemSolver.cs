using System.Diagnostics;

namespace MontyHallProblem;

public sealed class MontyHallProblemSolver
{
    private readonly bool[][] _testCases;

    private readonly int[] _choices;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="testCases">Represents 3 doors, where <c>true<c> is a win.</param>
    /// <param name="choices">Represents choice for test case</param>
    public MontyHallProblemSolver(bool[][] testCases, int[] choices)
    {
        _testCases = testCases;
        _choices = choices;
    }

    public MontyHallProblemSolver()
        : this(MontyHallProblemDefaults.DefaultTestCases, MontyHallProblemDefaults.DefaultChoices) { }

    public void Run(MontyHallStrategy strategy)
    {
        if (!ValidateTestCases(_testCases, _choices))
        {
            Log("Invalid test cases.\n\r" +
                "All test cases must have exactly 3 values and only 1 with true value.\n\r" +
                "Choices count must be same count as test cases and withing 0 and 2 inclusively", ConsoleColor.Red);

            return;
        }

        var wins = 0;

        for (int i = 0; i < _testCases.Length; i++)
        {
            var testCase = _testCases[i];
            var choice = _choices[i];

            var before = testCase[choice];

            var indexOfLastDoor = GetIndexOfLastDoor(choice, testCase);

            var finalChoice = strategy switch
            {
                MontyHallStrategy.DoNotChangeDoor => before,
                MontyHallStrategy.ChangeDoor => testCase[indexOfLastDoor],
                _ => throw new UnreachableException()
            };

            if (finalChoice)
            {
                wins++;
            }
        }

        Log($"Usage of {strategy} strategy brought you {wins} wins in {_testCases.Length} games", ConsoleColor.Green);
    }

    /// <summary>
    /// Compares choice, assumes that Monty Hall showed another failure door and returns index of last untouched door
    /// <para>
    /// E.g. Choice == 0, Monty Hall shows door No.1, so returns 2.
    /// </para>
    /// </summary>
    /// <param name="choice"></param>
    /// <param name="testCase"></param>
    /// <returns></returns>
    private static int GetIndexOfLastDoor(int choice, bool[] testCase)
    {
        if (choice == 0)
        {
            if (testCase[1])
            {
                return 1;
            }

            return 2;
        }

        if (choice == 1)
        {
            if (testCase[2])
            {
                return 2;
            }

            return 0;
        }

        if (testCase[0])
        {
            return 0;
        }

        return 1;
    }

    private static bool ValidateTestCases(bool[][] testCases, int[] choices)
    {
        return testCases
            .All(test => test.Length == 3 && test.SingleOrDefault(x => x) is not false)
            && choices.Length == testCases.Length
            && choices.All(c => c >= 0 && c <= 2);
    }

    private static void Log(string message, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
