namespace MontyHallProblem;

/// <summary>
/// Just default test cases
/// </summary>
internal static class MontyHallProblemDefaults
{
    public static int[] DefaultChoices => new[]
    {
        0, 0, 0,
        1, 1, 1,
        2, 2, 2,
    };

    public static bool[][] DefaultTestCases => new bool[][]
    {
        [true, false, false],
        [false, true, false],
        [false, false, true],
        [true, false, false],
        [false, true, false],
        [false, false, true],
        [true, false, false],
        [false, true, false],
        [false, false, true],
    };
}
