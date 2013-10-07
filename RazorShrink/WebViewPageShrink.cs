using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace RazorShrink
{
    public class WebViewPageShrink<T> : WebViewPageShrink
    {
        public override void Execute()
        {

        }
    }

    public abstract class WebViewPageShrink : WebViewPage
    {
        public override void Write(object value)
        {
            if (value != null)
            {

            }
            base.Write(value);
        }

        public override void WriteLiteral(object value)
        {
            if (value != null && !IsDebuggingEnabled())
            {
                value = Regex.Replace((string)value, @"\s*\n\s*", string.Empty, RegexOptions.Multiline);
                value = Regex.Replace((string)value, @"\s{2,}", " ", RegexOptions.Multiline);
            }
            base.WriteLiteral(value);
        }

        /// <summary>
        /// Debugging mode or not ??
        /// </summary>
        /// <returns></returns>
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