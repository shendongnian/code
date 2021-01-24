                SqlConnection connorder = new SqlConnection("Data Source=P4\\WORK;Initial Catalog=Agenda_X1;Persist Security Info=True;User ID=sa;Password=xxx");
                connorder.Open();
                string ordernrsql = lbOrderNr.Text;
                string newstate = lbNewState.Text;
                SqlCommand commandorder = new SqlCommand("UPDATE [Agenda_X1].[dbo].[Order] SET Note = @lbNewState WHERE OrderNr= @ordernumber", connorder);
                commandorder.Parameters.Add("@ordernumber", SqlDbType.NVarChar).Value = ordernrsql;
                commandorder.Parameters.Add("@lbNewState", SqlDbType.NVarChar).Value = newstate;
