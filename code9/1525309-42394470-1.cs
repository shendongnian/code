    var lineTransformers = textEditor.TextArea.TextView.LineTransformers;
    
    // Remove the original SelectionColorizer.
    // Note: if you have syntax highlighting you need to do something else
    // to avoid clearing other colorizers. If too complicated you can skip
    // this step but to suffer a 2x performance penalty.
    lineTransformers.Clear();
    
    lineTransformers.Add(new ColorizeSearchResults());
    lineTransformers.Add(
        new SelectionColorizerWithBackground(textEditor.TextArea));
