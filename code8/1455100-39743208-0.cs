    int? protocol = 5;
            bool age = true;
            var gender = true;
            string columns = "";
            if (protocol == 5)
            {
                columns += "Patient Id,";
            }
            if (age)
            {
                columns += "Age,";
            }
            if (gender)
            {
                columns += "Gender,";
            }
            columns += columns.TrimEnd(',');
