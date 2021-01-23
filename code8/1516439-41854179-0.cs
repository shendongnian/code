            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                List<Group_Days_TB> groupadd = new List<Group_Days_TB>();
                foreach (int i in listBoxControl1.SelectedIndices)
                {
                    groupadd.Add(new Group_Days_TB(
                        int.Parse(TxtID.Text.ToString()),
                        int.Parse(TypeDescriptor.GetProperties(listBoxControl1.Items[i])[listBoxControl1.ValueMember].ToString()),
                        TimeSpan.Parse(textEdit1.Text.ToString()),
                        DateTime.Parse(timeEdit1.Text.ToString()),
                        DateTime.Parse(timeEdit2.Text.ToString())
                        ));
                }
                db.Group_Days_TBs.InsertAllOnSubmit(groupadd);
                db.SubmitChanges();
            }
