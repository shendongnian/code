       private void selectbtn_Click(object sender, EventArgs e)
        {
            
            string[] checkedtitles = new string[checkedListBox1.CheckedItems.Count];
            for (int ii = 0; ii < checkedListBox1.CheckedItems.Count; ii++)
            {
                checkedtitles[ii] = checkedListBox1.CheckedItems[ii].ToString();
            }
            string selectedSongs = String.Join(Environment.NewLine, checkedtitles);
            songRecord.writeRecord(selectedSongs);
            this.Close();
        }
