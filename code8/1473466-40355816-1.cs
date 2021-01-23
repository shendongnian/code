    public List<string> TextBoxesText
    {
        get 
        {
            List<string> result = new List<string>();
            foreach (Button btn in Controls.OfType<Button>())
            {
                result.Add(btn.Text);
            }
            return result; 
        }
    }
