    public string checkwinnner() 
    {  
        int size = n;
    
        //check rows
        bool okay = true;
        for (int i = 0; i < size; i++)
        {
            bool rowOkay = true;
            //start at 1, compare with previous
            for (int j=1; j<size;j++)
            {
               //this cell is blank doesn't match it's neighbor
               if (bar[i,j].Text == "" || bar[i, j-1].Text != bar[i,j].Text)
               {
                   rowOkay = false;
                   j=size;
               }
            }
            if (rowOkay) return bar[i,0].Text;
        }
    
        //TODO (per Question OP): Implement columns and diagonals
        return "";
    }
    var winner = checkwinnner();
    if (winner != "")
    {
        MessageBox.Show(winner + " won.");
    }
