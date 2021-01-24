     bool isfound = false;
            for (int i = 0; i < 3; i++)
            {
                isfound = false;
                for (int j = 0; j < present.Length; j++)
                {
                    if (allstd[i] == present[j])
                    {
                        isfound = true;
                    }
                }
                if (!isfound)
                {
                    MessageBox.Show(allstd[i]);
                }
            }
