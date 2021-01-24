    case 1:
                        // add 3 points
                        var AddWin = (from Team in db.TeamTBLs
                                     where selected.TeamName == Team.TeamName
                                     select Team ).FirstOrDefault();                                         
                            AddWin.Points=AddWin.Points+3;
                            db.Entry(AddWin).State = System.Data.Entity.EntityState.Modified;     
                        break;
     case 2:
                        // add 1 point
                        var AddDraw = from Team in db.TeamTBLs
                                      where selected.TeamName == Team.TeamName
                                      select Team ).FirstOrDefault();
                        AddDraw.Points=AddWin.Points+1;
                         db.Entry(AddDraw).State = System.Data.Entity.EntityState.Modified;   
                        break;
