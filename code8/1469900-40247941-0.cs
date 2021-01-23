    public static class OpenXmlExtension
    {
        public static void AddFormattedText(this Run run, string textToAdd)
        {
            var texts = textToAdd.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < texts.Length; i++)
            {
                if (i > 0)
                    run.Append(new Break());
                Text text = new Text();
                text.Text = texts[i];
                run.Append(text);
            }
        }
    }
