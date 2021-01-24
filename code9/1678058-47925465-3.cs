    using (var connection = Database.connection)
    {
        String Track1Genre = @"
          INSERT 
          INTO TrackGenre(TrackId, GenreId) 
          VALUES (
            (SELECT id FROM track WHERE titel = @titel), /* do a select for the ID */
            (SELECT id FROM genre WHERE genre = @genre))";
        string Genre = listBoxGenre.GetItemText(listBoxGenre.SelectedItem);
        using (SqlCommand sqlCmd = new SqlCommand(Track1Genre, connection))
        {
    
            // caution, better use Add, see the note
            sqlCmd.Parameters.AddWithValue("@titel", textBoxTitel.Text);
            sqlCmd.Parameters.AddWithValue("@Genre", Genre);
            sqlCmd.ExecuteNonQuery();
        }
    }
