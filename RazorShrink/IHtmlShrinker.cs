using System.Web;

namespace RazorShrink
{
    public interface IHtmlShrinker
    {
        bool RawRewriteEnabled
        {
            get;
        }
        IHtmlString Shrink(IHtmlString val);
        string Shrink(string val);
    }
}