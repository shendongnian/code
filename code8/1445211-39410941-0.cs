    void UpdateQuantity() {
            // your connection string
            MySqlDataAdapter adp = new MySqlDataAdapter("Select * from table where ItemID = " + 13 + " Order BY expiry", cnn); // I have test db and I used it
            DataTable dt = new DataTable();
            adp.Fill(dt);
            int deductNum = 50;
            foreach (DataRow item in dt.Rows)
            {
                int value = (int)item["quantity"];
                if (value >= deductNum) // if had enough stock we don't need to pass the next line
                {
                    int result = value - deductNum;
                    item["quantity"] = result.ToString();
                    break; // so need to exit from loop
                }
                else
                {
                    deductNum -= value; // else we deduct value count from deduction
                    item["quantity"] = 0; // quantity finished so it will be 0
                }
            }
            MySqlCommandBuilder cmb = new MySqlCommandBuilder(adp);
            adp.UpdateCommand = cmb.GetUpdateCommand();
            adp.Update(dt);
            dataGridView1.DataSource = dt; //to show the result
        }
