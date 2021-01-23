    IEnumerable<ColoredSpan> DescribeLine(int lineNumber)
    {
        var lineSpan = sourceText.Lines[lineNumber].Span;
        var classified = Classifier.GetClassifiedSpans(semanticModel, lineSpan, workspace);
        var cursor = lineSpan.Start;
        // Presuming you need a string rather than a TextSpan.
        Func<TextSpan, string> textOf = x => sourceText.ToString(x);
        if (!classified.Any())
            yield return new ColoredSpan(defaultStyle, textOf(lineSpan));
        foreach (var overlap in classified)
        {
            var classified = overlap.TextSpan.Intersection(lineSpan).Value;
            if (classified.Start > cursor)
            {
                var unclassified = new TextSpan(cursor, classified.Start - cursor);
                cursor = classified.Start;
                yield return new ColoredSpan(defaultStyle, textOf(unclassified));
            }
            var style = StyleFromClassificationType(overlapping.ClassificationType);
            yield return new ColoredSpan(style, textOf((TextSpan)classified));
            cursor = classified.Start + classified.Length;
        }
        if (cursor < lineSpan.Start + lineSpan.Length)
        {
            var trailing = new TextSpan(cursor, lineSpan.Start + lineSpan.Length - cursor);
            yield return new ColoredSpan(defaultStyle, textOf(trailing));
        }
    }
