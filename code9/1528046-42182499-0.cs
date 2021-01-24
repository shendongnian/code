            List<TextRange> ranges = new List<TextRange>();
            foreach (Paragraph p in rtb.Document.Blocks.OfType<Paragraph>())
            {
                TextPointer pointer = null;
                foreach (Run r in p.Inlines.OfType<Run>())
                {
                    int index = r.Text.IndexOf(".");
                    if (index != -1)
                    {
                        pointer = r.ContentStart.GetPositionAtOffset(index);
                    }
                }
                 
                var firsSentence = new TextRange(p.ContentStart, pointer);
                ranges.Add(firsSentence);
            }
            foreach (var r in ranges)
            {
                r.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
