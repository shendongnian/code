    var charCount = textbox.Text
        .GroupBy(c => c)
        .ToDictionary(x => x.Key, x => x.Count());
    
    var parenthesisCount = charCount['('] + charCount[')']; // 4
    var yCount = charCount['y']; // 2
