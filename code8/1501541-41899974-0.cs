    using System.Linq;
    using DocumentFormat.OpenXml.Wordprocessing;
    namespace OxmlApp
    {
        static class WordprocessingExtensions
        {
            public static void ReplaceTextInTextDescendants(this Body body, string oldText, string newText)
            {
                foreach (var textItem in body.Descendants<Text>().Where(textItem => textItem.Text.Contains(oldText)))
                {
                    textItem.Text = textItem.Text.Replace(oldText, newText);
                }
            }
        }
    }
