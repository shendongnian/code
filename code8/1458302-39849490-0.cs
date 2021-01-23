            string line;
            string[] columns = null;
            bool foundHotels = false;
            while ((line = sr.ReadLine()) != null)
            {
                columns = line.Split(',');
                if (columns.Contains(tboxName.Text))
                {
                    rtBoxResults.Text = ((columns[0] + " " + columns[1] + " " + columns[2] + " " + columns[3]));
                   foundHotels = true;
                }
             }
           
             if(!foundHotels)
             {
                 MessageBox.Show("No Hotels Found.");               
             }
