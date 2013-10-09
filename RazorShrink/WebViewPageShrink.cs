using System.Web;
using System.Web.Mvc;

namespace RazorShrink
{
    public abstract class WebViewPageShrink : WebViewPage
    {
        protected WebViewPageShrink()
        {
            if (!HtmlShrinker.IsDebuggingEnabled())
            {
                Shrinker = new HtmlShrinker();
            }
        }

        public IHtmlShrinker Shrinker
        {
            get;
            set;
        }

        public override void Write(object value)
        {
            if (Shrinker != null && Shrinker.RawRewriteEnabled && value is IHtmlString)
            {
                value = Shrinker.Shrink((IHtmlString)value);
            }

            base.Write(value);
        }

        public override void WriteLiteral(object value)
        {
            if (Shrinker != null && value != null)
            {
                value = Shrinker.Shrink((string)value);
            }
            base.WriteLiteral(value);
        }

    }

    public abstract class WebViewPageShrink<T> : WebViewPage<T>
    {
        protected WebViewPageShrink()
        {
            if (!HtmlShrinker.IsDebuggingEnabled())
            {
                Shrinker = new HtmlShrinker();
            }
        }

        public IHtmlShrinker Shrinker
        {
            get;
            set;
        }

        public override void Write(object value)
        {
            if (Shrinker != null && Shrinker.RawRewriteEnabled && value is IHtmlString)
            {
                value = Shrinker.Shrink((IHtmlString)value);
            }

            base.Write(value);
        }

        public override void WriteLiteral(object value)
        {
            if (Shrinker != null && value != null)
            {
                value = Shrinker.Shrink((string)value);
            }
            base.WriteLiteral(value);
        }
    }
}
