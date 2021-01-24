    public void Gamble()
        {
            var rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                int r = (int)(rnd.NextDouble() * (fruits.Length - 1));
    
                MessageBox.Show(r.ToString());
    
                GambledFruits.Add(fruits[r]);
            }
        }
