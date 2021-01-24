            int no = 0;
            string query = "select count(*) from ConditionalEarnings where [Double Duty]!=0";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                no = Convert.ToInt32(cmd.ExecuteScalar());
            }
            string selectQuery = "select a.EmpId,b.EmpRunningBasic from ConditionalEarnings a left join EmployeeRunningBasic b on a.EmpId=b.EmpId  where a.[Double Duty]!=0";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, DataFind);
            DataTable dtEmp;
            adapter.Fill(dtEmp);
            textBox7.Text = no.ToString();
            string updateQuery = "";
            foreach (DataRow row in dtEmp)
            {
                string empId = row["EmpId"].ToString();
                textBox8.Text = empId;
                int rb = Convert.ToInt32(row["EmpRunningBasic"]);
                int doublechange = Convert.ToInt32(textBox1.Text);
                int apply = (rb * doublechange) / 100;
                updateQuery += string.Format("Update  ConditionalEarnings set [Double Duty]='{1}' where EmpId='{0}';", empId, apply);
            }
            if (!string.IsNullOrEmpty(updateQuery))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
