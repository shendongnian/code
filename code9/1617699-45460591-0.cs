    try
    {
        if (string.IsNullOrEmpty(openFileDialog1.FileName))
        {
            MessageBox.Show("You need to select the file to open");
        }
        else
        {
            // Only attempt to do this if you know the user selected some value
            doc.Load(openFileDialog1.FileName);
        }
    }
    catch (ArgumentException ex)
    {
        //Show some error that is not caused by the URL being empty
    }
