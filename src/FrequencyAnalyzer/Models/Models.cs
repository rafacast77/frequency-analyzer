namespace FrequencyAnalyzer.Models;

public record CharacterFrequency(char Character, int Count);

public record AnalysisResult(
    int TotalCharacters,
    IReadOnlyList<CharacterFrequency> TopCharacters);