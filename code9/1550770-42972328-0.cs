    private void btnSummary_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("EVENTS.TXT"))
            {
                string line = string.Empty;
                /*the condition in the while reads the next line and puts it in line, 
                   then tests if line is null because sr.ReadLine() 
                   returns null when the end of the document is reached*/
                while ((line = sr.ReadLine()) != null) 
                {
                    //Do your tests on line
                }
            }
        }
