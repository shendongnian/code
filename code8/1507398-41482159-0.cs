    {
    string url = "http://maps.google.com/maps/api/geocode/xml?address=" + Location.Text + "&sensor=false";
    try{
    WebRequest request = WebRequest.Create(url);
    using (WebResponse response = (HttpWebResponse)request.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        {
            DataSet dsResult = new DataSet();
            dsResult.ReadXml(reader);
            DataTable dtCoordinates = new DataTable();
            dtCoordinates.Columns.AddRange(new DataColumn[4] 
            { 
                new DataColumn("Id", typeof(int)),
                    new DataColumn("Address", typeof(string)),
                    new DataColumn("Latitude",typeof(string)),
                    new DataColumn("Longitude",typeof(string)) 
            });
            //  if (response["status"] == OK)
            //   {
            foreach (DataRow row in dsResult.Tables["result"].Rows)
            {
                string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                // TextBox1.Text = location["lat"];
                dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
                // TextBox1.Text = dsResult.Tables["lat"].ToString;
                // TextBox2.Text = location["lng"];
            }
            GridView1.DataSource = dtCoordinates;
            GridView1.DataBind();
    }
    catch(Exception err)
    {
        if(err.Message.Contains("instance is not set"))//Check if you get error code then match error code
        {
            Console.Write("Custom message"); 
            MessageBox.Show("Custom message");
        }
        else
        { 
            Console.Write("Normal message"); 
            MessageBox.Show("Normal message");
        }
    }
    }
