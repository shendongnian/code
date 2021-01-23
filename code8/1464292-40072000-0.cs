    //Date for loop
            List<string> ChartDates = new List<string>();
            int i = -29, j = 0;
            while (i <= j)
            {
                ChartDates.Add(DateTime.Now.AddDays(i).ToShortDateString());
                i++;
            }
            
            //Addmission Data Value for Chart
            List<int> AddmissionData = new List<int>();
            int k = -29, l = 0;
            while (k <= l)
            {
               AddmissionData.Add(0);
                k++;
            }
            //Counting Addmission Per Day 
            List<int> Addmissions = new List<int>();
            List<string> AddmissionDate = new List<string>();
            SqlCommand cmd = new SqlCommand("select count(Add_id), Std_submit_date from IMS_Addmission WHERE Std_submit_date >= dateadd(day, datediff(day, 0, GetDate()) - 30, 0)GROUP BY Std_submit_date", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Addmissions.Add(Convert.ToInt32(dr[0].ToString()));
                DateTime cd7 = Convert.ToDateTime(dr["Std_submit_date"].ToString(), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                string datenow = cd7.ToShortDateString();
                AddmissionDate.Add(datenow);
            }
            dr.Close();
            con.Close();
            int b = 0;
            foreach (string str in ChartDates)
            {
                int c = 0;
                foreach(string str2 in AddmissionDate)
                {
                    if(str == str2)
                    {
                        AddmissionData[b] = Addmissions[c];
                    }
                    c++;
                }
                
                b++;
            }
            // Sending Addmission Data For Chart
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("var Addmission_No = new Array;");
            foreach (int str in AddmissionData)
            {
                sb.AppendFormat("Addmission_No.push({0});", str);
            }
            sb.Append("</script>");
            //sending data through client script register
            ClientScript.RegisterStartupScript(this.GetType(), "AddmissinNo", sb.ToString());
            // (Addmission_No) is the array containg Value for Chart.
            //Addmission Data For Chart End
 
