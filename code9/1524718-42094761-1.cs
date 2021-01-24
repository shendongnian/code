    public void HandleListBoxItemClicked(object sender, EventArgs e)
    {
        Potion p_parent = sender as Potion;
    
        if(p != null)
        {      
            pTypeInput.SelectedItem = p._type;
            pMagInput.Value = p._magnitude;
            pNameInput.Text = p._name;
            pBonusInput.Checked = p._bonus;
        }
    }
