    try
    {
        pleaseWait.Show();
        Application.DoEvents();
        int RowC = await FillAndGetRowCount( ... );
        pleaseWait.Close();
        if (RowC == 0)
        {
            MessageBox.Show(GlobVar.NoResults, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
