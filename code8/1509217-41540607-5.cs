    private void btnDelete_Click(object sender, EventArgs e)
    {
       int deleteCost = 0;
       int itemCost = 0;
       foreach(int selectedIndex in lstProductChosen.SelectedIndices)
       {
           itemCost = int.Parse(lstProductChosen.Items[selectedIndex].ToString().Split('-')[1]); 
           deleteCost += itemCost; lstProductChosen.Items.RemoveAt(selectedIndex);
       }
    
       totalcost = totalcost - deleteCost;
    
       lbTotalCost.Text = ("Php" + totalcost.ToString());
    }
