    public class WritesRowsOfHtml
    {
        public void BeginHtmlDocument(StringBuilder document)
        {
            document.Append("<html><body>");
        }
        public void WriteTable(StringBuilder document, IEnumerable<ThingContainingValues> things)
        {
            document.Append("<table>");
            foreach (var thing in things)
            {
                document.AppendFormat("<tr><td class=\"tg-baqh\">{0}</td><td class=\"tg-baqh\">{1}</td></tr>",
                    thing.Value1, thing.Value2);
            }
            document.Append("</table>");
        }
        public void EndHtmlDocument(StringBuilder document)
        {
            document.Append("</body></html>");
        }
    }
