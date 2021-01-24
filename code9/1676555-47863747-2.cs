    using System.Linq;
    ...
    public static CheckForEmptyTextBoxes(System.Collections.IEnumerable collection) {
      return collection
        .OfType<TextBox>()
        .Any(textBox => string.IsNullOrEmpty(textBox.Text));
    }
    ...
    if (CheckForEmptyTextBoxes(myPanel.Controls)) {
      // If there's an empty TextBox on myPanel 
    }
