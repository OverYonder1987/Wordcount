using WordCountCore;

namespace UnitTest;

[TestClass]
public class WordCounterTests
{
    private WordCounter? _sut;

    [TestInitialize]
    public void Init()
    {
        _sut = new WordCounter();
    }

    [TestMethod]
    public void CountWords_ShouldBeOrderedByNumberOfOccurrences()
    {
        var text = PrepareTestInput();

        var expectedResult = PrepareExpectedDictionary();

        var result = _sut!.CountWords(text);

        Assert.IsTrue(result.First().Value == 3);
        Assert.IsTrue(result.Last().Value == 1);
    }

    [TestMethod]
    public void CountWords_WordsShouldTotal447()
    {
        var text = Ipsum;

        var result = _sut!.CountWords(text);

        var sum = result.Sum(r => r.Value);

        Assert.AreEqual(447, sum);
    }

    private Dictionary<string, int> PrepareExpectedDictionary()
    {
        return new Dictionary<string, int>
        {
            { "the", 1 },
            { "brown", 1 },
            { "fox", 3 },
            { "jumped", 2 },
            { "over", 1 }
        };
    }

    private string PrepareTestInput()
    {
        return "the brown? FOX; fox fox jumped \njuMped. \tover";
    }

    private string Ipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas non odio scelerisque, posuere lacus in, auctor nunc. Etiam dignissim in ipsum at commodo. Vivamus eget enim id tortor sodales varius. Ut velit leo, consequat id accumsan id, tincidunt nec sapien. Ut sit amet tortor at orci volutpat venenatis. Fusce malesuada sit amet est maximus accumsan. Proin id venenatis mi, ut aliquet mauris. Ut lobortis lorem ultrices quam bibendum mattis. Duis porttitor mauris ut nunc facilisis lobortis. Integer fringilla venenatis accumsan.\r\n\r\nDuis ultrices molestie lacus, nec dignissim diam commodo quis. Morbi rutrum lectus vel viverra eleifend. Mauris facilisis varius magna, ut fermentum tortor condimentum vitae. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras massa libero, viverra ac placerat et, luctus id nunc. Proin sit amet dolor at neque vulputate gravida. Duis ornare augue ac augue convallis imperdiet. Donec blandit commodo finibus. Fusce urna ex, bibendum ac lobortis ut, aliquet eu sem. Quisque venenatis metus eu diam tristique, ac tincidunt enim egestas. Quisque felis risus, pharetra at vestibulum ac, viverra et sem. Quisque sit amet pellentesque dui. Donec pulvinar augue ut ante semper mollis. Nulla iaculis purus vitae rutrum pulvinar. Phasellus mattis lobortis justo non eleifend.\r\n\r\nFusce gravida facilisis neque, a maximus enim venenatis quis. Curabitur eu dui consectetur, imperdiet mauris sit amet, iaculis lorem. Morbi convallis pharetra ligula non tempor. Proin blandit lorem in ex gravida, in congue magna pulvinar. Integer ornare aliquet est. Quisque rutrum tempus quam id facilisis. Suspendisse gravida velit nulla. Morbi a nisl accumsan, finibus magna in, finibus purus. Aliquam erat volutpat.\r\n\r\nIn finibus, libero ut dignissim euismod, ipsum ipsum lobortis odio, eget rutrum enim tellus nec risus. Praesent mollis tortor nec mattis iaculis. Pellentesque auctor dui at sodales blandit. Sed convallis tortor nulla, rutrum viverra mi mattis in. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In hac habitasse platea dictumst. Donec laoreet sapien vitae sapien pellentesque consequat.\r\n\r\nFusce aliquet vestibulum ligula vel gravida. Quisque facilisis dignissim maximus. Etiam aliquet velit eros, ut laoreet libero mattis sed. Curabitur nec eros vehicula, feugiat odio quis, lacinia urna. Suspendisse ultricies ex massa, et convallis quam viverra vel. Fusce rutrum diam ut arcu luctus suscipit. Nunc massa tellus, sodales vel purus vel, volutpat vehicula tortor. Proin lobortis enim et nunc mollis gravida. Sed scelerisque purus vel erat tempor, eu faucibus tellus tincidunt. Morbi ex nisi, ullamcorper sit amet viverra at, consectetur in dui. In lectus eros, aliquet nec rhoncus a, ultricies et sem. Donec quis volutpat velit, eu consectetur sem. Duis quis tortor vel nisi consequat faucibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus rhoncus mi vitae velit rutrum euismod. Morbi nec turpis vitae turpis malesuada feugiat.";
}