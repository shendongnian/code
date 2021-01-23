    public static async Task ReadReadyAsync()
    {
        if (!BCS_complete) return;
        if (Read1_complete && Read2_complete)
            await Task.Run(() => W1_SQL_Write.SQL_Write_Enabled());
        if (Read3_complete && Read4_complete)
            await Task.Run(() => W2_SQL_Write.SQL_Write_Enabled());
        if (Read5_complete && Read6_complete)
            await Task.Run(() => W3_SQL_Write.SQL_Write_Enabled());
    }
