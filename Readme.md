# ⏱️ SmartTimeSpanParser

> A developer-friendly .NET library for parsing natural time duration expressions like `"2h 30m"` or `"1.5 days"` into usable `TimeSpan` objects.

## 🚀 Features

- Fluent parsing of expressions like:
  - `2h`, `1.5 hours`
  - `30 minutes`, `45m`, `90s`
  - `1h 15m`, `2 days 3h`
- Converts human input to `TimeSpan`
- Small, fast, and dependency-free
- Perfect for config parsing, retries, timeouts, and CLI tools

## 📦 Installation

Install from NuGet (coming soon):

```bash
dotnet add package SmartTimeSpanParser
```

## 📌 Example Usage

```csharp
var duration = SmartTimeSpan.Parse("2h 30m");

Console.WriteLine(duration); // 02:30:00

if (SmartTimeSpan.TryParse("45 minutes", out var parsed))
{
    Console.WriteLine(parsed); // 00:45:00
}
```

## 💡 Supported Formats

| Input | Description |
|-------|-------------|
| `2h` | 2 hours |
| `1.5 days` | 36 hours |
| `30m` or `30 minutes` | 30 minutes |
| `90s` | 90 seconds |
| `1h 15m` | 1 hour and 15 minutes |
| `2d 3h` | 2 days and 3 hours |

More formats and units coming soon!

## 🛠️ Planned Roadmap

- [ ] `ToHumanString()` method for output like `"2 hours, 15 minutes"`
- [ ] Support for milliseconds
- [ ] Support plural/locale parsing (`fr`, `de`, `es`)
- [ ] CLI tool for parsing and formatting durations

## 🔄 Changelog

See [CHANGELOG.md](CHANGELOG.md)

## 🧪 Run Tests

```bash
dotnet test
```

## 🤝 Contributing

Pull requests welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for details.

## 📄 License

MIT — see [LICENSE](LICENSE)

---

⭐ If you find this useful, give it a star!
