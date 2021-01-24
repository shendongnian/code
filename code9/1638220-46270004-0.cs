    try
    {
        // Your code goes here
    }
    catch (DivideByZeroException ex)
    {
        MessageBox.Show("Cannot divide by zero! " + ex.Message);
    }
    catch (Exception ex)
    {
        // This is a generic exception
        MessageBox.Show("Error: " + ex.Message);
    }
