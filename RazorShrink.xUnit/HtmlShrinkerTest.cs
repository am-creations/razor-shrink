using System.IO;
using Xunit;

namespace RazorShrink.xUnit
{
    public class HtmlShrinkerTest
    {
        const string ActualDirectory = "Actual";
        const string ExpectedDirectory = "Expected";

        [Fact]
        public void TestRegexShrink()
        {
            var s = new HtmlShrinker();

            var di = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory().Replace("\\bin\\Debug", ""), ActualDirectory));
            foreach (var f in di.GetFiles("*.html"))
            {
                var actualContent = File.ReadAllText(f.FullName);
                var expectedContent = File.ReadAllText(f.FullName.Replace(ActualDirectory, ExpectedDirectory));

                var strB = s.Shrink(actualContent);
                Assert.Equal(0, string.CompareOrdinal(expectedContent, strB));
            }
        }
    }
}
