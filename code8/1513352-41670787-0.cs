            while (Reader.Read())
            {
                try
                {
                    iname = Reader["FirstName"].ToString();
                    isurname = Reader["Surname"].ToString();
                    int.TryParse(Reader["IDNumber"].ToString(), out iIDNO);
    
                    models.Add(new ListClients
                    {
                        Name = iname,
                        Surname = isurname,
                        IDNO = iIDNO
                    });
            }
