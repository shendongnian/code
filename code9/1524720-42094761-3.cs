    public void HandleListBoxItemClicked(object sender, EventArgs e)
    {
        Potion p_parent = sender as Potion;
    
        if(p_parent != null)
        {      
            pTypeInput.SelectedItem = p_parent._type;
            pMagInput.Value = p_parent._magnitude;
            pNameInput.Text = p_parent._name;
            pBonusInput.Checked = p_parent._bonus;
        }
    }
