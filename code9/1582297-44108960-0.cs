            public void Update_Ynet_Rss()
        {
            if(Ynet_Rss.Text == "")
            {
                Run_Ynet_Rss();
            }
            // Ynet_Rss.Text = Ynet_Rss.Text.Substring(0, Ynet_Rss.Text.Length-1);
            string s = Ynet_Rss.Text;
           // MessageBox.Show("Index = " + s.IndexOf("מבזקים"));
            if (s[0] >= 'א' && s[0] <= 'ת')
            {
                string tmp = "";
                string tmp2 = "";
                //Ynet_Rss.Text = Cutting(Ynet_Rss.Text, 0, s.IndexOf(" "));
                int EndIndex = -1;
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z'))
                    {
                        EndIndex = i;
                        //MessageBox.Show("EndIndex = " + EndIndex + "s[i] = " + s[i].ToString());
                        break;
                    }
                }
                if(EndIndex == -1)
                {
                 //   MessageBox.Show("EndIndex = " + EndIndex);
                    EndIndex = s.Length;
                }
                //tmp = Ynet_Rss.Text.Substring(Ynet_Rss.Text.IndexOf(" "));
                tmp = Ynet_Rss.Text.Substring(EndIndex);
                tmp2 = Ynet_Rss.Text.Substring(0, EndIndex);
              //  MessageBox.Show("V1 = " + tmp2);
                tmp2 = Ynet_Rss.Text.Substring(0, tmp2.Length-1);
           //     MessageBox.Show("V2 = " + tmp2);
                Ynet_Rss.Text = tmp2 + tmp;
            }
            else
            {
                Ynet_Rss.Text = Ynet_Rss.Text.Substring(1);
            }
               Ynet_Rss.TextAlignment = TextAlignment.Left;
        }
