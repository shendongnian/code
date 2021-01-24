    while ((line = sr2.ReadLine()) != null)
    {
        lines[us] = line;
    
        if (lines[us] == usernam)
        {
            check = 1;
            MessageBox.Show(usernam);
            Form2 f2 = new Form2();
            this.Hide();
            break;
        }
        us++;
    }
