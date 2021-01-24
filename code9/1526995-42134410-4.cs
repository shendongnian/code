    decimal IfValueIsConvertibleItWillBeHeldHere = 0;
    if(decimal.TryParse(txt_cost.Text.Split(' ')[0], out IfValueIsConvertibleItWillBeHeldHere)
    { 
        frm_BookingPg frm_HomePge = new frm_BookingPg(
            cbo_Destination.Text, 
            cbo_AmountOfPeople.Text, 
            (int)IfValueIsConvertibleItWillBeHeldHere // see the difference ?
        );
    
        frm_HomePge.Show();
        this.Hide();
    }
    else
    {
        // show some message to the user that input was invalid
    }
