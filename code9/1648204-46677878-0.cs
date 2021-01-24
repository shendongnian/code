    private void DynamicButton_Click(object sender, EventArgs e)
    {
        // Assign text local variable
        var searchText = this.dynamicTextBox.Text;
        // Load lines of text file
        var lines = File.ReadAllLines("names.txt");
        
        string result = null;
        foreach(var line in lines) {
            // Check if the line contains our search text, note this will find the first match not necessarily the best match
            if(line.Contains(searchText)) {
                // Result found, assign result and break out of loop
                result = line;
                break;
            }
        }
        
        // Display the result, you could do more such as splitting it to get the age and name separately
        MessageBox.Show(result ?? "No results");
    }
