    List<Model.UserSetUp> objUserSetUp = objUserSetUp1.Select(m => new Model.UserSetUp()
            {
                Id = m.UserId,
                FirstName = m.FirstName,
                SurName = m.SurName,
                Computer_Name = m.Computer_Name,
                IP_Address = m.IP_Address,
                LogInTime = m.LogInTime,
                UserName = Decrypt(m.UserName),
                Password = Decrypt(m.Password),
                login_Id = m.login_Id,
                UserType = m.UserId == 0 ? "UnKnown" :"Documents Scanned",
                countID = m.docCount
            }).ToList();
