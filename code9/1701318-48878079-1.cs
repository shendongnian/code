        foreach(Control ctrl in PlaceHolder1.Controls)
        {
            if(ctrl is Panel)
            {
                foreach(Control ctrlPnl in ctrl.Controls)
                {
                    if(ctrlPnl is Table)
                    {
                       foreach(TableRow row in ((Table)ctrlPnl).Rows)
                        {
                            foreach(TableCell cel in row.Cells)
                            {
                                foreach(Control ctrlCell in cel.Controls)
                                {
                                    if(ctrlCell is RadioButtonList)
                                    {
                                        //Do your stuff here
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
