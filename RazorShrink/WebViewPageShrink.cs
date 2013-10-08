using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace RazorShrink
{
    public abstract class WebViewPageShrink<T> : WebViewPageShrink
    {
    }

    public abstract class WebViewPageShrink : WebViewPage
    {
        private static readonly Regex RegexEmptyLines = new Regex(@"\s*\n\s*", RegexOptions.Compiled | RegexOptions.Multiline);
        private static readonly Regex RegexOverSpace = new Regex(@"\s{2,}", RegexOptions.Compiled | RegexOptions.Multiline);

        public override void WriteLiteral(object value)
        {
            if (value != null && !IsDebuggingEnabled())
            {
                value = RegexEmptyLines.Replace((string)value, string.Empty);
                value = RegexOverSpace.Replace((string)value, " ");
            }
            base.WriteLiteral(value);
        }

        /// <summary>
        /// Debugging mode or not ??
        /// </summary>
        private static bool IsDebuggingEnabled()
        {
#if TEST_WHITESPACE_CLEANER
            return false;
#endif
            return
                System.Web.HttpContext.Current == null
                || System.Web.HttpContext.Current.IsDebuggingEnabled;
        }
    }
}