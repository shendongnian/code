        public static string TextFromWord(string filename)
        {
            StringBuilder textBuilder = new StringBuilder();
            using (WordprocessingDocument wDoc = WordprocessingDocument.Open(filename, false))
            {
                var parts = wDoc.MainDocumentPart.Document.Descendants().FirstOrDefault();
                if (parts != null)
                {
                    foreach (var node in parts.ChildElements)
                    {
                        if(node is Paragraph)
                        {
                            ProcessParagraph((Paragraph)node, textBuilder);
                            textBuilder.AppendLine("");
                        }
                        if (node is Table)
                        {
                            ProcessTable((Table)node, textBuilder);
                        }
                    }
                }
            }
            return textBuilder.ToString();
        }
        private static void ProcessTable(Table node, StringBuilder textBuilder)
        {
            foreach (var row in node.Descendants<TableRow>())
            {
                textBuilder.Append("| ");
                foreach (var cell in row.Descendants<TableCell>())
                {
                    foreach (var para in cell.Descendants<Paragraph>())
                    {
                        ProcessParagraph(para, textBuilder);
                    }
                    textBuilder.Append(" | ");
                }
                textBuilder.AppendLine("");
            }
        }
        private static void ProcessParagraph(Paragraph node, StringBuilder textBuilder)
        {
            foreach(var text in node.Descendants<Text>())
            {
                textBuilder.Append(text.InnerText);
            }
        }
