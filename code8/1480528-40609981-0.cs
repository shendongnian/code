    public static async Task ReadReadyAsync()
    {
        if (!BCS_complete) return;
        await Task.Run(() => W1_SQL_Write.SQL_Write_Enabled());
        await Task.Run(() => W2_SQL_Write.SQL_Write_Enabled());
        await Task.Run(() => W3_SQL_Write.SQL_Write_Enabled());
    }
