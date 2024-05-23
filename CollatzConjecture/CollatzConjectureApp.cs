namespace CollatzConjecture;

public class CollatzConjectureApp
{
    public static void Run(int start)
    {
        if (start <= 0)
        {
            Console.WriteLine("Start number must be greater than 0.");
            return;
        }

        decimal number = start;

        var iterations = 0;

        while (number != 1)
        {
            Console.WriteLine(number);

            if (number % 2 == 0)
            {
                number = ProcessEvenNumber(number);
            }
            else
            {
                number = ProcessOddNumber(number);
            }

            iterations++;
        }

        Console.WriteLine(number);
        
        Console.WriteLine($"It takes {iterations} steps to go from {start} to 4, 2, 1 sequence.");
    }

    private static decimal ProcessOddNumber(decimal number)
    {
        return (number * 3) + 1;
    }

    private static decimal ProcessEvenNumber(decimal number)
    {
        return number / 2;
    }
}
