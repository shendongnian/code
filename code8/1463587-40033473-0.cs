    public async void TextChanged()
    {
        textbox.IsEnabled = false;
        try
        {
            if(textbox.Text.Length > 5) //< This sucks and I know it. 
            {
                string text = textbox.Text;
                await Task.Run(()=>doSomeMadlyDemandingRandomStuff(text));
                textbox.IsEnabled = true;
            }
        }
        catch(Exception ex)
        {
         //Bloody exception is never caught.
        }
    }
