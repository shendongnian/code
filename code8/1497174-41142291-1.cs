            private StringBuilder ReadingListView()
        {
            string delimiter = ",";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string[] arr = new string[5];
                arr[0] = listView1.Items[i].SubItems[0].Text;
                arr[1] = listView1.Items[i].SubItems[1].Text;
                arr[2] = listView1.Items[i].Tag.ToString();
                arr[3] = listView1.Items[i].SubItems[3].Text;
                arr[4] = listView1.Items[i].SubItems[4].Text;
                sb.AppendLine(string.Join(delimiter, arr.ToArray()));
            }
            return sb;
        }
