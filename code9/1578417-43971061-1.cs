    private void btnSave_Click(object sender, EventArgs e)
    {
        // Grab the selected vendor name
        string selectedName = cboVendors.SelectedItem.ToString();
        // Grab the original phone number for this vendor
        string originalPhone = vendorPhones[selectedName];            
        // Read all the file lines into an array:
        var fileLines = File.ReadAllLines("Vendor.txt");
            
        // Now we iterate over the file lines one by one, looking for a match
        for (int i = 0; i < fileLines.Length; i++)
        {
            // Break the line into parts to see if this line is the one we need to update
            string[] lineParts = fileLines[i].Split(',');
            string name = lineParts[1];
            string phone = lineParts[6];
            // Compare this line's name and phone with our originals
            if (name == selectedName && phone == originalPhone)
            {
                // It's a match, so we will update the phone number part of this line
                lineParts[6] = txtPhone.Text;
                // And then we join the parts back together and assign it to the line again
                fileLines[i] = string.Join(",", lineParts);
                // Now we can break out of the loop since we updated our vendor info
                break;
            }
        }
        // Finally, we can write all the lines back to the file
        File.WriteAllLines("Vendor.txt", fileLines);
        // May not be necessary, but if you're reading back from the file right away
        // then update the dictionary with the new phone number for this vendor
        vendorPhones[selectedName] = txtPhone.Text;
    }
