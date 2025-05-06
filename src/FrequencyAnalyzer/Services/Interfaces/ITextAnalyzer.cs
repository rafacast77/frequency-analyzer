namespace FrequencyAnalyzer.Services;

using FrequencyAnalyzer.Models;

public interface ITextAnalyzer
{
    AnalysisResult AnalyzeFile(string filePath, bool caseSensitive = true);
    AnalysisResult AnalyzeText(string text, bool caseSensitive = true);
}