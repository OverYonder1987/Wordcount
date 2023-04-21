using System.Text.RegularExpressions;
using WordCountCore.interfaces;

namespace WordCountCore;

public class WordCounter : IWordCounter
{
    private readonly char[] _separators = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '\t' };

    public Dictionary<string, int> CountWords(string text)
    {
        var words = text.Split(_separators);

        var sanitizedWords = SanitizeWords(words);

        Dictionary<string, int> wordCount = new();

        foreach (var word in sanitizedWords)
        {
            var wordLower = word.ToLowerInvariant();
            if (wordCount.ContainsKey(wordLower))
            {
                wordCount[wordLower]++;
            }
            else
            {
                wordCount.Add(word.ToLowerInvariant(), 1);
            }
        }

        var orderedWordCount = wordCount
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        return orderedWordCount;
    }

    private static List<string> SanitizeWords(string[] words)
    {
        var sanitizedWords = new List<string>();

        foreach (var word in words)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                continue;
            }

            var regex = new Regex(@"^\w+$");

            var match = regex.Match(word);

            if (!match.Success)
            {
                continue;
            }

            sanitizedWords.Add(word.Trim());
        }

        return sanitizedWords;
    }
}