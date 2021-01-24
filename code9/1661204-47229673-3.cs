     for(int i = 0; i < checkedListBox1.Items.Count; i++)
        {
        var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                        .Select(x => this.checkedListBox1.GetItemText(x));
            IdFundosSelecionados.Add(text)
     }
     
