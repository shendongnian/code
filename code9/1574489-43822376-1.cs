    public string longText = "This is a test text that is reasonably long";
    public string enrichedText = "";
    
    public void RichTextBox1_TextChanged()
    {
        enrichedText = Console.ReadLine();
        if (enrichedText.Length <= longText.Length)
        {
            enrichedText.Remove(enrichedText.Length - 1, 1);
            enrichedText += longText[enrichedText.Length - 1];
        }     
    }
