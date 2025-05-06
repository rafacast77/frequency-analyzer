namespace FrequencyAnalyzer;

// Could move CharacterFrequency and AnalysisResult to models folder and make them proper classes
public record CharacterFrequency(char Character, int Count); 
public record AnalysisResult(int TotalCharacters, IReadOnlyList<CharacterFrequency> TopCharacters);

public class TextAnalyzer
{
    private static readonly char[] WhiteSpaceChars = { ' ', '\r', '\n', '\t' };

    // Validates the input file, reads and return it's content.)
    public AnalysisResult AnalyzeFile(string filePath, bool caseSensitive = true)
    {
        // Could add further validation for MaxSize and FileType
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file was not found.", filePath);
        // Could use stream reader if requirement includes large files
        var text = File.ReadAllText(filePath);
        return AnalyzeText(text, caseSensitive);
    }
    
    // Prepares the text for analysis, counts the frequency of each character, and returns the result.
    public AnalysisResult AnalyzeText(string text, bool caseSensitive = true)
    {
        // Check if the text is null or empty
        if (string.IsNullOrWhiteSpace(text))
        {
            return new AnalysisResult(0, new List<CharacterFrequency>());
        }

        // Process the text to remove whitespace and convert to lowercase if not case-sensitive
        var processedText = !caseSensitive
            ? text.ToLower().Where(c => !WhiteSpaceChars.Contains(c))
            : text.Where(c => !WhiteSpaceChars.Contains(c));

        // Count the frequency of each character
        var frequencies = processedText
            .GroupBy(c => c)
            .Select(g => new CharacterFrequency(g.Key, g.Count()))
            .OrderByDescending(f => f.Count)
            .ThenBy(f => f.Character)
            .Take(10)
            .ToList();

        return new AnalysisResult(
            processedText.Count(),
            frequencies
        );
    }
}