        DateTime dt;
        bool parsed = DateTime.TryParse("119/08", out dt); //returns true
        parsed = DateTime.TryParse("119/08/02", out dt); //returns true
        parsed = DateTime.TryParse("119.08.02", out dt); //returns true
        parsed = DateTime.TryParse("119.08", out dt); //returns true
        parsed = DateTime.TryParse("119-08-02", out dt); //returns true
        parsed = DateTime.TryParse("119-08", out dt); //returns true
        parsed = DateTime.TryParse("119 08 02", out dt); //returns true
        parsed = DateTime.TryParse("119 08", out dt); //returns true
        parsed = DateTime.TryParse("119:08:02", out dt); //invalid as colon : is time sesparator, so API can't figure out date at all
        parsed = DateTime.TryParse("119:08", out dt); //invalid as colon : is time sesparator, so API can't figure out date at all
