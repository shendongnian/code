    if (string.IsNullOrEmpty(txtDateLastSeen.Text.Trim())
    {
        sc.Parameters.AddWithValue("@DateLastSeen", DbNull.Value);
    }
    else
    {
        sc.Parameters.AddWithValue("@DateLastSeen", txtDateLastSeen.Text);
    }
