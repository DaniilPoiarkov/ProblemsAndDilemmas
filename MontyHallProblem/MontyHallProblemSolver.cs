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

        var choices = new List<bool>(_testCases.Length);

        for (int i = 0; i < _testCases.Length; i++)
        {
            var testCase = _testCases[i];
            var choice = _choices[i];

            var before = testCase[choice];

            var lastDoor = testCase[1] ? 1 : 2;

            var after = strategy == MontyHallStrategy.DoNotChangeDoor ? before : testCase[lastDoor];

            if (after)
            {
                choices.Add(after);
            }
        }

        Log($"Usage of {strategy} strategy brought you {choices.Count} wins in {_testCases.Length} games", ConsoleColor.Green);
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
