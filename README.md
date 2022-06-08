[![.NET Tests](https://github.com/sh1ch/Ngram/actions/workflows/dotnet.yml/badge.svg)](https://github.com/sh1ch/Ngram/actions/workflows/dotnet.yml)
[![CodeFactor](https://www.codefactor.io/repository/github/sh1ch/ngram/badge/master)](https://www.codefactor.io/repository/github/sh1ch/ngram/overview/master)

# n-gram

Measure the similarity of two strings based on n-gram method. (.NET C# library)

Based on [milk1000cc/trigram](https://github.com/milk1000cc/trigram).

# Usage 1 (compare)

```cs
var value = Ngram.Compare("he is genius", "he is genius"); // => 1
var value = Ngram.Compare("he is genius", "he is very genius"); // => 0.5625
var value = Ngram.Compare("he is genius", "she is cute"); // => 0.2666666...
var value = Ngram.Compare("he is genius", "I can fly"); // => 0
```

# Usage 2 (parse)

```cs
var charArray = Ngram.ParseToCharArray("she is cute", Size.Tri);
var strings = Ngram.ParseToString("she is cute", Size.Tri);

foreach (var str in strings)
{
  Console.WriteLine(str);
}
```
```txt
she
he_
e_i
_is
is_
s_c
_cu
cut
ute
```



