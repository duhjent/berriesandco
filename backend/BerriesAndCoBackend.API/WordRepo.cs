namespace BerriesAndCoBackend.API;

public class WordRepo
{
    private IReadOnlyDictionary<string, IEnumerable<string>> _words;

    public WordRepo()
    {
        _words = File
            .ReadAllLines("./Resources/words.txt")
            .GroupBy(x => new string(x.OrderBy(c => c).ToArray()))
            .ToDictionary(g => g.Key, g => g.Select(x => x));

    }

    public IEnumerable<string> GetAnagrams(string word)
    {
        return _words.TryGetValue(new string(word.OrderBy(c => c).ToArray()), out var result) ? result : [];
    }
}