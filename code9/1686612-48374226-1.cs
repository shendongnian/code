        private async void SaveContent()
        {
            byte[] bytes;
            StorageFile file = await DownloadsFolder.CreateFileAsync("file.rtf", CreationCollisionOption.GenerateUniqueName);
            if (file != null)
            {
                // write to file
                using (Windows.Storage.Streams.IRandomAccessStream randAccStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
                {
                    editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);
                    randAccStream.Seek(0);
                    var dataReader = new DataReader(randAccStream);
                    await dataReader.LoadAsync((uint)randAccStream.Size);
                    bytes = new byte[randAccStream.Size];
                    dataReader.ReadBytes(bytes);
                }
                SqliteConnection connection = new SqliteConnection("Filename=richEditBox.db");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS myTable (
                    content BLOB
                )
                ";
                command.ExecuteNonQuery();
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText =
                @"
                INSERT INTO myTable (content)
                VALUES (@content)
                ";
                insertCommand.Parameters.Add("@content", SqliteType.Blob, bytes.Length);
                insertCommand.Parameters["@content"].Value = bytes;
                var task1 = insertCommand.ExecuteNonQueryAsync();
            }
        }
        private async void LoadContent()
        {
            object[] values = new object[2];
            SqliteConnection connection = new SqliteConnection("Filename=richEditBox.db");
            connection.Open();
            var retrieveCommand = connection.CreateCommand();
            retrieveCommand.CommandText =
                @"SELECT * from myTable";
            var reader = retrieveCommand.ExecuteReader();
            while (reader.Read())
            {
                System.Diagnostics.Debug.WriteLine(reader.GetValues(values));
            }
            var dataBytes = values[0] as byte[];
            var dataBuffer = dataBytes.AsBuffer();
            InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
            await randomAccessStream.WriteAsync(dataBuffer);
            randomAccessStream.Seek(0);
            editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randomAccessStream);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveContent();
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }
