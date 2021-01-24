         using (SqlConnection conn = new SqlConnection(connStr))
                {
                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = conn;
                   cmd.CommandType = CommandType.Text;
                   cmd.CommandText =  "INSERT INTO SalesActivity(Activity_ID, Date, Quatation_Number, Customer_ID, Product_ID, Quantity, valueGBR, valueEUR, Rate, weightedValue, Status_ID, estDecisionDate, PromisedDeliveryDate) values(@Activity,@Date, @param3 ,@param4,@param5,@param6,@param7,@param8,etc................... )";                }
               cmd.Parameters.AddWithValue("@Activity", Convert.ToInt32(txtActivity.Text));
        }
