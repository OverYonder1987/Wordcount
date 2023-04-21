namespace WordCountCore.interfaces;

public interface IWordCounter
{
    Dictionary<string, int> CountWords(string text);
}
