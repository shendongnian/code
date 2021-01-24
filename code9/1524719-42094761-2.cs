    public EventHandler ListBoxItemClicked;
    private void pPotionList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Potion p = pPotionList.SelectedItem as Potion;
        pPotionList.SelectionMode = SelectionMode.One;
        if (p != null)
        {                
            if (ListBoxItemClicked != null)
            {
                ListBoxItemClicked(p, new EventArgs());
            }    
        }
    }
