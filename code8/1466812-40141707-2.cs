    Character selectedCharacter;
    Character otherSelectedCharacter;
    
    public void lstbxCharacter1_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedCharacter = characters.ElementAt(lstbxCharacter1.SelectedIndex);
         ....
    }
    
    public void DisplayWinner()
    {
       if (selectedCharacter.IsBetterThan(otherSelectedCharacter))
        ...
    }
