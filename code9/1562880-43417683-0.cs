                       using (mTableRow = new HtmlTableRow()){
                        {
                            #region Radio Button
                            using (HtmlTableCell lTableCell = new HtmlTableCell())
                            {
                                RadioButton mradioButton = new RadioButton();
                                    mradioButton.ID = "Radio" + listInfo.ID;
                                    mradioButton.GroupName = "rowSelector1";
                                    mradioButton.AutoPostBack = true;
                                    mradioButton.Checked = false;
                                    mradioButton.CheckedChanged += new EventHandler(AvailableRadioButton_CheckedChanged);
                                    lTableCell.Attributes["class"] = "RadioButton";
                                    lTableCell.Controls.Add(mradioButton);
                                
                                    mTableRow.Cells.Add(lTableCell);
                                    #endregion
                             // add all the remaining columns
                               // add table row to the table.
