    using System.Linq;
    ...
    richTextBox2.Lines = richTextBox2
      .Lines
      .Select((line, index) => $"{index + 1} {line}")
      .ToArray();
