          foreach (GridViewRow gvr in gvSerials.Rows)
                {
                    //Moved record up
                    if (Priority < e.RowIndex + 1)
                    {
                        //Greater than priority but less than index - Increase Prioirty
                        if (gvr.RowIndex + 1 >= Priority && gvr.RowIndex < e.RowIndex)
                            DAL.UpdatePriority(gvr.RowIndex + 2, int.Parse(gvSerials.DataKeys[gvr.RowIndex]["SerialID"].ToString()));
                    }
                    else if (Priority > e.RowIndex + 1)
                    {
                        if (gvr.RowIndex > e.RowIndex)
                        {
                            if (gvr.RowIndex + 1 <= Priority)
                                DAL.UpdatePriority(gvr.RowIndex, int.Parse(gvSerials.DataKeys[gvr.RowIndex]["SerialID"].ToString()));
                        }
                    }
                }
