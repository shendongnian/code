    public List<string> Class1Data
    {
        get 
        {
            List<string> result = new List<string>();
            foreach (Button btn in Controls.OfType<Button>())
            {
                if (btn.Tag.ToString().Equals("Class1"))
                    result.Add(btn.Text);
            }
            return result; 
        }
    }
