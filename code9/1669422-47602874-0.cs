    public void ButtonHandlers(Type NewForm)
        {
          
                NewButton.Click += (sender, args) =>
                {
                    Form TheNewMain = (Form)Activator.CreateInstance(NewForm);
                    if (TheNewMain.ShowDialog() != DialogResult.Cancel)
                    {
                        TheNewMain.Activate();
                    }
                };
