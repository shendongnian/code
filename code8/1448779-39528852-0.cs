    var textBlock = new TextBlock { TextWrapping = TextWrapping.NoWrap };
 
    var boldRun = new Run("This is a bit of bold text.");
    boldRun.FontWeight = FontWeights.Bold;
    textBlock.Inlines.Add(boldRun);
 
    var normalRun = new Run("This is not very bold.);
    textBlock.Inlines.Add(normalRun );
 
    ...
    quickInfoContent.Add(textBlock);
