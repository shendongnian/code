    void _timer_0_Tick(object sender, EventArgs e)
       {
          bool isDataStable = //code to determine if stable on my end
          if(isDataStable == true)
            {
                DataGrid.Rows[Index].Cells["Status"].Style.BackColor = Color.Green;
            }
          else
            {
                DataGrid.Rows[Index].Cells["Status"].Style.BackColor = Color.Red;
            }
       }
