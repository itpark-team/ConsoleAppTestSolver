namespace ConsoleAppTestSolver;

public static class Util
{
    public static int InputInt(string msg, int min, int max)
    {
        bool inputReault;
        int number;

        Console.Write(msg);

        do
        {
            inputReault = int.TryParse(Console.ReadLine(), out number);

            if (min > number || number > max)
            {
                inputReault = false;
            }
        } while (!inputReault);

        return number;
    }
}