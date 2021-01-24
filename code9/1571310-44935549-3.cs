     string image = (@"C:\Capture.PNG");
            
            string[] results = UseImageSearch(image, "30");
            if (results == null)
            {
                MessageBox.Show("null value bro, sad day");
            }
            else
            {
                MessageBox.Show(results[1] + ", " + results[2]);
            }
