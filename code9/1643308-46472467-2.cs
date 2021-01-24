    public bool checkwinnner() 
    {  
        int size = 3;
    
        //check rows
        for (int i = 0; i < size; i++)
        {
            //part of the row is blank, so continue to next row
            if (bar[i,0].Text == ""  || bar[i,1].Text == "" || bar[i,2].Text == "") 
               continue;
    
            //Whole row has the same value, then they win
            if (bar[i,0].Text == bar[i,1].Text && bar[i,1].Text == bar[i,2].Text)
                  return bar[i,0].Text;
        }
    
        //TODO (per Question OP): Implement columns and diagonals
        return "";
    }
    var winner = checkwinnner();
    if (winner != "")
    {
        MessageBox.Show(winner + " won.");
    }
