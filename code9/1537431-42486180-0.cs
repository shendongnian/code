            int index = 0;
            for (int i = 0; i < para.Count(); i++)
            {
                if (para.ElementAt(i).GetType() == typeof(W.Run))
                {
                    index = i;
                }
            }
            para.InsertAt(run, index);  
