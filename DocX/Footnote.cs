using System.Linq;
using System.Xml.Linq;

namespace Novacode
{
    public class Footnote : DocXElement
    {
        internal Footnote(DocX document, XElement xml) : base(document, xml)
        {
            Id = xml.GetAttribute(XName.Get("id", DocX.w.NamespaceName));
            var footnoteElement = document.footnotes.Descendants(XName.Get("footnote", DocX.w.NamespaceName)).First(f => f.GetAttribute(XName.Get("id", DocX.w.NamespaceName)) == Id);
            Text = HelperFunctions.GetText(footnoteElement);
        }

        public string Text { get; private set; }
        public string Id { get; private set; }
    }
}