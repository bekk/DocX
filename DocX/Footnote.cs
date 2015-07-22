using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Novacode
{
    public class Footnote : DocXElement
    {
        public List<FormattedText> MagicText
        {
            get
            {
                try {
                    return HelperFunctions.GetFormattedText(Xml);
                } catch (Exception) {
                    return null;
                }
            }
        }

        public string Text => HelperFunctions.GetText(Xml);
        public string Id => Xml.GetAttribute(XName.Get("id", DocX.w.NamespaceName));

        internal Footnote(DocX document, string footnoteId) : base(document, GetFootnodeXml(document, footnoteId))
        {
        }

        private static XElement GetFootnodeXml(DocX document, string footnoteId) =>
            document.footnotes.Descendants(XName.Get("footnote", DocX.w.NamespaceName)).First(f => f.GetAttribute(XName.Get("id", DocX.w.NamespaceName)) == footnoteId);
    }
}