      private void insertWordCount(string songId, string wordId, int wordCount)
        {
            string query = "insert into songs_words_conn values(@wordId,@songId,@wordCount)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@wordId", wordId);
            cmd.Parameters.AddWithValue("@songId", songId);
            cmd.Parameters.AddWithValue("@wordCount", wordCount);
            cmd.ExecuteNonQuery();
        }
