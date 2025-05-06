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
        var text = "HELLO world";

        // Act
        var result = _analyzer.AnalyzeText(text, caseSensitive: false);

        // Assert
        Assert.Equal(10, result.TotalCharacters);
        Assert.Equal('l', result.TopCharacters[0].Character); // Most frequent
        Assert.Equal(3, result.TopCharacters[0].Count);      // 2 from HELLO, 1 from world
        Assert.Equal('o', result.TopCharacters[1].Character); // Second most frequent
        Assert.Equal(2, result.TopCharacters[1].Count);      // 1 from HELLO, 1 from world
    }

    [Fact]
    public void AnalyzeText_CaseSensitive_CountsCharactersSeparately()
    {
        // Arrange
        var text = "HELLO world";

        // Act
        var result = _analyzer.AnalyzeText(text, caseSensitive: true);

        // Assert
        Assert.Equal(10, result.TotalCharacters);
        Assert.Equal('L', result.TopCharacters[0].Character); // Most frequent
        Assert.Equal(2, result.TopCharacters[0].Count);      // From HELLO
        // All other characters appear once
        Assert.Equal(1, result.TopCharacters[1].Count);      // Next character appears once
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