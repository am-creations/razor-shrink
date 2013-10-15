using Xunit;

namespace RazorShrink.xUnit
{

    public class HtmlShrinkerTest
    {
        [Fact]
        public void TestRegexShrink()
        {
            var s = new HtmlShrinker();
            Assert.Equal("", "");
        }
    }
}
