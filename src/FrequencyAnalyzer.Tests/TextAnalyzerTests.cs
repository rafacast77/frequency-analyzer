
namespace FrequencyAnalyzer.Tests;

public class TextAnalyzerTests
{
    private readonly TextAnalyzer _analyzer = new TextAnalyzer();

    [Fact]
    public void AnalyzeText_WithSampleText_ReturnsCorrectResult()
    {
        // Arrange
        var text = "The three did feed the deer\nThe quick brown fox jumped over the lazy dog";

        // Act
        var result = _analyzer.AnalyzeText(text);

        // Assert
        Assert.Equal(58, result.TotalCharacters);
        Assert.Equal(10, result.TopCharacters.Count);
        Assert.Equal('e', result.TopCharacters[0].Character);
        Assert.Equal(12, result.TopCharacters[0].Count);
    }

    [Fact]
    public void AnalyzeText_CaseInsensitive_CombinesSameCharacters()
    {
        // Arrange
        var text = "Hello World";

        // Act
        var result = _analyzer.AnalyzeText(text, caseSensitive: false);

        // Assert
        Assert.Equal(10, result.TotalCharacters);
        Assert.Equal('l', result.TopCharacters[0].Character);
        Assert.Equal(3, result.TopCharacters[0].Count);
    }

    [Fact]
    public void AnalyzeText_IgnoresWhitespace()
    {
        // Arrange
        var text = "a b\tc\nd\re";

        // Act
        var result = _analyzer.AnalyzeText(text);

        // Assert
        Assert.Equal(5, result.TotalCharacters);
    }

    [Fact]
    public void AnalyzeText_EmptyInput_ReturnsZeroCharacters()
    {
        // Arrange
        var text = string.Empty;

        // Act
        var result = _analyzer.AnalyzeText(text);

        // Assert
        Assert.Equal(0, result.TotalCharacters);
        Assert.Empty(result.TopCharacters);
    }
}

public class AnalysisResult
{
    public int TotalCharacters { get; }
    public List<CharacterFrequency> TopCharacters { get; }

    public AnalysisResult(int totalCharacters, List<CharacterFrequency> topCharacters)
    {
        TotalCharacters = totalCharacters;
        TopCharacters = topCharacters;
    }
}

public class CharacterFrequency
{
    public char Character { get; }
    public int Count { get; }

    public CharacterFrequency(char character, int count)
    {
        Character = character;
        Count = count;
    }
}