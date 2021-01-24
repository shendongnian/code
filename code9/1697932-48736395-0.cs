    var csvRecords = File
                .ReadAllLines(filePath)
                .Select(c => c.Split(',')).Select(c => new
                {
                    Date = c[0],
                    DropDown = c[1],
                    LastName = c[2],
                    FirstName = c[3],
                    Email = c[4],
                    Phone = c[5],
                    Home = c[6],
                    Info = c[7],
                    Primary = c[8],
                    Email2 = c[9],
                    SecondaryEmail = c[10]
                }).ToList();
    foreach (var csvRecord in csvRecords)
            {
                var date = csvRecord.Date;
                var dropdownindex = csvRecord.DropDown;
                LasttextBox.Text = csvRecord.LastName;
                FirsttextBox.Text = csvRecord.FirstName;
                EmailtextBox.Text = csvRecord.Email;
                PhonetextBox.Text = csvRecord.Phone;
                HometextBox.Text = csvRecord.Home;
                InfotextBox.Text = csvRecord.Info;
                PrimarytextBox.Text = csvRecord.Primary;
                EmailtextBox.Text = csvRecord.Email2;
                SecondaryEmailtextBox.Text = csvRecord.SecondaryEmail;
            }
