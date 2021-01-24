    // The event handler: make async. The only one that still returns void
    async void OnButton1_clicked(object sender, ...)
    {
        // start fetching the data. Don't await yet, you'll have other things to do
        Task<MyData> fetchDataTask = FetchData(...);
        // meanwhile: show the user that you are busy:
        this.ShowBusy(true); // show picture box?
        // if needed do other things you can do before the data is fetched
        this.ClearTable();
        // once you have nothing meaningful to do, await for your data
        MyData fetchedData = await fetchDataTask;
        this.ProcessData(fetchedData);
        // finished: 
        this.ShowBusy(false); // remove picture box
    }
    // async version:
    async Task<IQueryable<MyData>> FetchDataAsync(myParams)
    {
        using (SqlConnection dbConnection = new SqlConnection(...)
        {
            // open the connection, don't wait yet:
            Task taskOpen = sqlCommand.OpenAsync();
            // continue while opening:
            using (var sqlCommand = new SqlCommand(...))
            {
                cmd.Parameters.AddWithValue(...);
                // before executing the query: wait until OpenAsync finished:
                await taskOpen;
                // read the data. If nothing to do: await, otherwise use Task similar to Open
                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();
                foreach (var row in dataReader)
                { 
                    ... (some Await with GetFieldValueAsync
                }
            }
        }
    }
