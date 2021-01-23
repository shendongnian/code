    string[] columns = null;
            var isHotels = false;
            while ((line = sr.ReadLine()) != null)
            {
                columns = line.Split(',');
                if (columns.Contains(tboxName.Text))
                {
                    rtBoxResults.Text = ((columns[0] + " " + columns[1] + " " + columns[2] + " " + columns[3]));
                    isHotels = true;
                }
            } // while loop ends
            if (!isHotels)
            {
                MessageBox.Show("No Hotels Found.");
                break;
            }
