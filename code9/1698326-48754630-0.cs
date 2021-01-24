    DateTime Date1 = dpReceived1.SelectedDate.Value;
                    DateTime Date2 = dpReceived2.SelectedDate.Value;
                    var strComment = cBoxComments.Text;
                    var results = data.tblInmates.Where(a => a.comments.Contains(cBoxComments.Text) && (a.RecDate >= Date1 && a.RecDate <= Date2)).Take(RadGridMax);
                    RadGrid1.DataSource = results.ToList().OrderByDescending(a => a.RecDate);
                    RadGrid1.DataBind();
