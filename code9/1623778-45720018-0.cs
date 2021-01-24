                // hiding the column header -- Added code start here ---
                gv.HeaderRow.Cells[0].Visible = false;
                // hiding the column detail
                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    GridViewRow row = gv.Rows[i];
                    row.Cells[0].Visible = false;
                }
                // ------------------  Added code ended here ------
                
                // following code are the same
                gv.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
