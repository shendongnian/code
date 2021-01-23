    private void UnwantedNoneRemover(TextBox textBox) {
       var lines = textBox.Lines;
       var updatedLines = new List<string>();
       foreach (var line in lines) {
           if (line != "None") { updatedLines.Add(line); }
       }
       textBox.Lines = updatedLines.ToArray();
    }
