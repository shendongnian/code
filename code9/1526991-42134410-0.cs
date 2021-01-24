    int IfValueIsConvertibleItWillBeHeldHere = 0;
    if(int.TryParse(txt_cost, out IfValueIsConvertibleItWillBeHeldHere)
    { 
        frm_BookingPg frm_HomePge = new frm_BookingPg(
            cbo_Destination.Text, 
            cbo_AmountOfPeople.Text, 
            IfValueIsConvertibleItWillBeHeldHere // see the difference ?
        );
    
        frm_HomePge.Show();
        this.Hide();
    }
    else
    {
        // show some message to the user that input was invalid
    }
      
