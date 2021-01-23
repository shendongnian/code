    Int32 pessengerId;
    if( !Int32.TryParse( ddlPessengerList.Text, out pessengerId ) ) {
        // abort, show error message
        return;
    }
    DateTime msnDate = msnDate.Value; // your `msnDate` control should have a strongly-typed way of getting the raw DateTime value, you should not attempt to parse a textual representation of a date/time.
    if( msnDate < new DateTime( 2016, 01, 01 ) ) {
        // sanity-check the date range, if it's too far in the past or future reject it, according to your business rules
        return;
    }
    SqlCommand cmd = cs.CreateCommand();
    cmd.CommandText = "INSERT INTO tbl_musannet ( pessenger_id, mus_date ) VALUES( @passengerId, @musDate )";
    cmd.Parameters.AddWithValue("@pessenger_id", pessengerId );
    cmd.Parameters.AddWithValue("@musDate ", msnDate);
    
    cs.Open();
    cmd.ExecuteNonQuery();
    cs.Close()
