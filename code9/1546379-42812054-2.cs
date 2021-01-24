     var startDateTZ = _startDate.Substring(20, 4);
            if (startDateTZ[3] == ' ')
            {
                startDateTZ = _startDate.Substring(20, 3);
            }
            if (startDateTZ.Length > 3)
            {
                if (startDateTZ[3] == '0')
                {
                    startDateTZ = _startDate.Substring(19, 4);
                }
                if (startDateTZ[3] == '2')
                {
                    startDateTZ = _startDate.Substring(19, 3);
                }
            }
            var startDate = new DateTime();
            if (_startDate[9] != ' ')
            {
                 startDate = DateTime.ParseExact(_startDate, "ddd MMM dd HH:mm:ss '" + startDateTZ + "' yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                 startDate = DateTime.ParseExact(_startDate, "ddd MMM d HH:mm:ss '" + startDateTZ + "' yyyy", CultureInfo.InvariantCulture);
            }
            model.StartDate = startDate;
