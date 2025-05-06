
using FrequencyAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide a file path as an argument.");
            return;
        }

        var filePath = args[0];
        var caseSensitive = args.Length > 1 ? bool.Parse(args[1]) : true;

        try
        {
            var analyzer = new TextAnalyzer();
            var result = analyzer.AnalyzeFile(filePath, caseSensitive);

            Console.WriteLine($"Total characters: {result.TotalCharacters}");
            foreach (var frequency in result.TopCharacters)
            {
                Console.WriteLine($"{frequency.Character} ({frequency.Count})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}