    int lines = -1; 
    int group = 500;
    while ((input = sr.ReadLine()) != null) 
        {
         lines++;
         if (lines%group == 0) {
            tr = m_dbConnection.BeginTransaction();
            }
