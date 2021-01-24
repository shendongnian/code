        private void button1_Click(object sender, EventArgs e)
        {  
            int season;
            int job;
            season = Convert.ToInt32(textBox1.Text);
            job = Convert.ToInt32(textBox2.Text);
            if (season == 1) 
            {
                if (job == 1)
                {
                    label3.Text = "There is a 20% discount on the exterior job";
                }
            }
            else
            {
                if (season == 2)
                {
                    if (job == 1)
                    {
                        label3.Text = "There is a 20% discount on the exterior job";
                    }
                }
            }
            else
            {
                if (season == 3)
                {
                    if (job == 2)
                    {
                        label3.Text = "There is a 30% discount on the interior job";
                    }
                }
            }
            else
            {
                 label3.Text = "No discount, regular prices apply";
            }
        }
