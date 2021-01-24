     private void GenerateNumbers_Click(object sender, EventArgs e)
            {
                List<int> nums = new List<int>(30);
                Random rnd = new Random();
                while (true)
                {
                    int num = rnd.Next(1, 250);
                    if (!nums.Contains(num))
                    {
                        nums.Add(num);
                    }
                    if (nums.Count == 30)
                    {
                        break;
                    }                
                }
                // elided
            }
