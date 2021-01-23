    dynamic mbr = null;
    switch (intAVersion)
    {
        case (int)A_Version.A6:
            mbr = new dbA6ReplDataContext();
            break;
        case (int)A_Version.A7:
            mbr = new dbA7ReplDataContext();
            break;
    }
    
