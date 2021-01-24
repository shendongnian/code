                Boolean gotnum;                
                gotnum = false;
                int idnum = 1;
                
                while  (gotnum != true)
                {
                    DrawingNumDBDataSet.AccountsRow actrw = drawingNumDBDataSet.Accounts.FindById(idnum);
                    idnum++;
                    if (actrw==null)
                    {
                        
                        gotnum = true;
                        idnum--;
                    }
   
                }
