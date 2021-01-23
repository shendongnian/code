    private string[]  _textLines;
    private TextAsset _textFile;
    private int       _currentLine;
    private void PrepareText()
        {
            _textFile = _textLoader.GetTextAsset();
            _textLines = (_textFile.text.Split('\n'));
    private void update() {
        if (Input.GetButtonDown("Continue"))
            _currentLine += 1;
        if (_textLines[_currentLine].Contains("(end)"))                           
            DisableTextBox();
    }
