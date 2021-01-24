    public int Compare(object x, object y)
    {
        try
        {
            // Parse the two objects passed as a parameter as a DateTime.
            int num1 =
                int.Parse(((ListViewItem)x).SubItems[col].Text);
            int num2 =
                    int.Parse(((ListViewItem)y).SubItems[col].Text);
            // Compare the two numbers.
            returnVal = int.Compare(num1, num2);
        }
        // If neither compared object has a valid int, compare
        // as a string.
        catch
        {
            // Compare the two items as a string.
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                        ((ListViewItem)y).SubItems[col].Text);
        }
    }
 
