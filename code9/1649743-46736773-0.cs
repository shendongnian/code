    internal static string oldAmount = string.Empty;
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        ... 
        cmd.Parameters.Add("@p_OldAmount", MySqlDbType.Decimal).Value = oldAmount;
        oldAmount = this.txtOTRate.Text;
    }
