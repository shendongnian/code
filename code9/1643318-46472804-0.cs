    public bool checkwinnner() 
    {  
        bool bw = true;
        for (int r = 0; r < n; r++)
        {
            bw = true;
            if (bar[r, 0].Text != "")
            {
                for (int c = 1; c < n; c++)
                {
                    if (bar[r, 0].Text != bar[r, c].Text)
                    {
                        bw = false;
                    }
                }
                //bw will remain true if and only if every cell in the row has the same symbol
                if (bw)
                {
                    //if bw is true then someone wins, so return true so the method terminates
                    return true;
                }
            }
        }
        //if we haven't already returned true, there is no winning row so return false
        return false;
    }
