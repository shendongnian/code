    ....
    dataAdapter.RowUpdated += onUpdate;
    ....
    private void onUpdate(object sender, SqlRowUpdatedEventArgs e)
    {
        Console.WriteLine(e.Row[0]);
        if (e.Errors != null)
        {
            Console.WriteLine(e.Errors.Message);
            Console.WriteLine("At row with key=" + e.Row["somecolumntoidentifytherow"]);
        }
    }
