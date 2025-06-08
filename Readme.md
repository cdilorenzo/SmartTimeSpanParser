# SmartTimeSpanParser

**SmartTimeSpanParser** is a lightweight .NET library that parses human-readable time span strings into `TimeSpan` objects.

## Features

- Parses inputs like `"2h 30m"`, `"1.5 days"`, `"45 minutes"`, etc.
- Supports multiple time units: days, hours, minutes, seconds
- Provides `Parse` and `TryParse` methods

## Installation

Install via NuGet:

```bash
dotnet add package SmartTimeSpanParser
```

## Usage

```csharp
using SmartTimeSpanParser;

var timeSpan = SmartTimeSpan.Parse("1h 30m");

if (SmartTimeSpan.TryParse("45 minutes", out var result))
{
    // result = 00:45:00
}
```

## License

This project is licensed under the MIT License.
