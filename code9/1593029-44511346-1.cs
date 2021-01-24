        private void deleteCallerRow(object sender, EventArgs e)
        {
            rowCount--;
            label1.Text = rowCount.ToString();
            Button delCaller = sender as Button;
            int callerTagNo = (int)delCaller.Tag;
            #region DeltePressedRowDelButton
            Control[] toBeRemovedDelButtons = pnl.Controls.Find("btnDelete" + callerTagNo, true);
            foreach (var delBtn in toBeRemovedDelButtons)
            {
                pnl.Controls.Remove(delBtn);
                delBtn.Dispose();
            }
            Control[] toBeRemovedFunctionButtons = pnl.Controls.Find("btnFunction" + callerTagNo, true);
            foreach (var funcBtn in toBeRemovedFunctionButtons)
            {
                pnl.Controls.Remove(funcBtn);
                funcBtn.Dispose();
            }
            #endregion
            #region Decrease Numbers in Buttons Texts, Tags and Names
            foreach (Control b in pnl.Controls)
            {
                if(b.Name.Contains("btnDelete"))
                {
                    if(callerTagNo < (int)b.Tag)
                    {
                        //Rename
                        int newTag = (int)b.Tag - 1;
                        b.Name = "btnDelete" + newTag;
                        b.Tag = newTag;
                        b.Text = "Delete " + newTag;
                    }
                }
                else if(b.Name.Contains("btnFunction"))
                {
                    if(callerTagNo < (int)b.Tag)
                    {
                        //Rename
                        int newTag = (int)b.Tag - 1;
                        b.Name = "btnFunction" + newTag;
                        b.Tag = newTag;
                        b.Text = "Function " + newTag;
                    }
                }
            }
            #endregion
        }
