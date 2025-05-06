using FrequencyAnalyzer.Models;

namespace FrequencyAnalyzer.Services;

public class TextAnalyzer : ITextAnalyzer
{
    private static readonly char[] WhiteSpaceChars = { ' ', '\r', '\n', '\t' };

    public AnalysisResult AnalyzeFile(string filePath, bool caseSensitive = true)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("The specified file was not found.", filePath);

        var text = File.ReadAllText(filePath);
        return AnalyzeText(text, caseSensitive);
    }

    public AnalysisResult AnalyzeText(string text, bool caseSensitive = true)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new AnalysisResult(0, new List<CharacterFrequency>());
        }

        // Convert to lowercase BEFORE filtering whitespace if case-insensitive
        var processedText = !caseSensitive 
            ? text.ToLower().Where(c => !WhiteSpaceChars.Contains(c))
            : text.Where(c => !WhiteSpaceChars.Contains(c));

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