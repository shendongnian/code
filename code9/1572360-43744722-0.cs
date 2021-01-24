     void t_Tick(object sender, EventArgs e)
        {
            foreach (var dateTime in _times)
            {
                TimeSpan ts = dateTime.Subtract(DateTime.Now);
                var hari = dateTimePicker1.Value.Day;
                Console.WriteLine(ts.Days);
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (ts.Days == 0)
                    {
                        listView1.Items[i].SubItems[3].Text = "DEADLINE";
                    }
                    else
                    {
                        listView1.Items[i].SubItems[3].Text = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds to go'");
                    }
                }
            }
        }
