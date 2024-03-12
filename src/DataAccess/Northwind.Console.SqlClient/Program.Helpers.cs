using System.Globalization; // To use CultureInfo

partial class Program
{
    private static void ConfigureConsole(string culture = "en-Us", bool useComputerCulture = false)
    {
        // To enable Unicode charaters like Euro symbol in the console
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"CultureInfo: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void WriteLineInColor(string value, ConsoleColor color = ConsoleColor.White)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = color;
        WriteLine(value);
        ForegroundColor = previousColor;
    }
}