using System.Text.RegularExpressions;
using System.Web;

namespace RazorShrink
{
    public class HtmlShrinker : IHtmlShrinker
    {
        private static readonly Regex RegexInlineJavascriptComment = new Regex(@"\/\/.*\n", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex RegexEmptyLines = new Regex(@"\s*\n\s*", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex RegexOverSpace = new Regex(@"\s{2,}", RegexOptions.Compiled | RegexOptions.Multiline);

        public bool RawRewriteEnabled
        {
            get
            {
                return true;
            }
        }

        public IHtmlString Shrink(IHtmlString val)
        {
            return new HtmlString(Shrink(val.ToHtmlString()));
        }

        public string Shrink(string val)
        {
            val = RegexInlineJavascriptComment.Replace(val, string.Empty);
            val = RegexEmptyLines.Replace(val, " ");
            val = RegexOverSpace.Replace(val, " ");

            return val;
        }

        /// <summary>
        /// Debugging mode or not ??
        /// </summary>
        public static bool IsDebuggingEnabled()
        {
#if TEST_RAZORSHRINK
            return false;
#endif

#if DONTUSE_RAZORSHRINK
            return true;
#endif
            return
                HttpContext.Current == null
                || HttpContext.Current.IsDebuggingEnabled;
        }
    }
}
