    string lines = outputToBox.ReadToEnd();
    StringBuilder builder = new StringBuilder();
    
    foreach (string line in lines.Split('\n'))
    {
       int index = line.IndexOf('@');
       builder.AppendLine(line.Substring(0, index));
    }
    
    txtDisplay.Text = builder.ToString();
