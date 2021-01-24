    private void ExportToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=name.xls");
        Response.Charset = "utf-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //To Export all pages
            gridview.AllowPaging = false;
            gridview.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gridview.HeaderRow.Cells)
            {
                cell.BackColor = Color.FromName("#4091A4");
                cell.ForeColor = Color.White;
                foreach (Control control in cell.Controls)
                {
                    if ((control.GetType().Name == "DataControlLinkButton") ||
                         (control.GetType().Name == "DataControlLinkButton"))
                    {
                        cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                        cell.Controls.Remove(control);
                    }
                }
            }
            foreach (GridViewRow row in gridview.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    List<Control> controls = new List<Control>();
                    
                    foreach (Control control in cell.Controls)
                    {
                        controls.Add(control);
                    }
                    cell.CssClass = "textmode";
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "HyperLink":
                                cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                break;
                            case "TextBox":
                                cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                break;
                            case "DataControlLinkButton":
                            case "LinkButton":
                                cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                            case "CheckBox":
                                cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                break;
                            case "RadioButton":
                                cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                break;
                        }
                        cell.Controls.Remove(control);
                    }
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gridview.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gridview.RowStyle.BackColor;
                    }
                    cell.HorizontalAlign = HorizontalAlign.Center;
                }
            }
            gridview.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
