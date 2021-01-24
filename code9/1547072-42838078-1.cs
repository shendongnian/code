    if (string.IsNullOrWhiteSpace(txtDateLastSeen.Text)
    {
        sc.Parameters.AddWithValue("@DateLastSeen", DbNull.Value);
    }
    else
    {
        sc.Parameters.AddWithValue("@DateLastSeen", txtDateLastSeen.Text);
    }
