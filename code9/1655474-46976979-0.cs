    private void SwitchControls(MyButton btnCurrent)
    {
        winLine current = ccContent.Content as winLine;
        if (current != null && current.Timer != null)
        {
            current.Timer.Stop();
            current.Timer.Dispose();
        }
        switch (btnCurrent.Name)
        {
            case "btnLine":
                {
                    winLine win = new winLine();
                    ccContent.Content = win;
                }
                break;
            case "btnHistory":
                {
                    winHistory win = new winHistory();
                    ccContent.Content = win;
                }
                break;
        }
    }
