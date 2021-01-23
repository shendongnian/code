          List<int> list = new List<int>();
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                list.Add(random.Next(1, 27));
            
            }
            foreach (int li in list)
            {
                s = String.Concat(s, Number2String(li, true) + " ");
               //string use =  Number2String(li, true);
                
            }
            MessageBox.Show(s);
