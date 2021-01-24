    // *Do not use.*
    // Simplest logic, but the database engines have issues in realising that
    // there is actually an implied "t.Column1 <= 10".
    ATable.Where(t => t.Column1 < 10 ||
                      t.Column1 == 10 && t.Column2 < 23);
    // Markus Winand's style. Confusing, IMO.
    ATable.Where(t => t.Column1 <= 10 &&
                      !(t.Column1 == 10 && t.Column2 >= 23));
    // My personal favourite.
    ATable.Where(t => t.Column1 <= 10 &&
                      (t.Column1 < 10 || t.Column2 < 23));
