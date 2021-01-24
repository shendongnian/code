    private void check_word_exists_Click(object sender, EventArgs e)
        {
            StopWordsDataSet.StopWordsRow wordsRow = stopWordsDataSet.StopWords.FindByword(query_word.Text);
            try
            {
                if (query_word.Text == wordsRow.word)
                {
                    query_word.Text = query_word.Text;
                    MessageBox.Show("Stop word '"+ query_word.Text + "' exists");
                    query_word.Text = "";
                }
                else
                {
                    MessageBox.Show("Stop word doesn't exists");
                }
            }catch(Exception)
            {
                query_word.Text = query_word.Text;
                MessageBox.Show("Stop word '"+ query_word.Text + "' doesn't exists");
                query_word.Text = "";
            }
        }
