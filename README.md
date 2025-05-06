# Frequency Analyzer

Frequency Analyzer is a .NET application that analyzes the frequency of characters in a given text or file. It provides insights into the total number of characters and the most frequently occurring characters.

## Features

* Analyze text input for character frequency.
* Analyze files for character frequency.
* Case-sensitive and case-insensitive analysis.
* Ignores whitespace characters.

## Requirements

* .NET 9.0 or later.

## Installation

1. Clone the repository:

   ```bash
   git clone <repository-url>
   ```

2. Build the solution:

   ```bash
   dotnet build
   ```

---

## Usage

### Command Line

Run the program with a file path:

```bash
dotnet run --project src/FrequencyAnalyzer <filepath> [case-sensitive]
```

### Parameters

* **filepath**: Path to the text file to analyze
* **case-sensitive**: Optional boolean parameter (default: `true`)

### Example

Using the sample file:

```bash
dotnet run --project src/FrequencyAnalyzer samples/sample.txt false
```

### Example Output

```
Total characters: 58
e (12)
t (7)
h (5)
r (5)
d (4)
o (4)
...
```

---

## Development

### Running Tests

Execute the test suite:

```bash
dotnet test
```

---

## Project Structure

```
src/FrequencyAnalyzer/       → Main application code
├── Services/                → Core analysis logic
├── Models/                  → Data models
src/FrequencyAnalyzer.Tests/ → Unit tests
samples/                     → Example text files
```