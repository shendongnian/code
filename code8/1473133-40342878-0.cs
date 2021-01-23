    var listItems = (from A in data
                        let logOutTimeParts = (A.LogOutTime ?? "Unknown").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        orderby A.FirstName
                        select new
                        {
                            Action = "Logout",
                            UserName = A.FirstName + " " + A.SurName,
                            ID = A.Id,
                            AccessDate = logOutTimeParts[0],
                            AccessTimeFrame = logOutTimeParts.Length >= 3 ? logOutTimeParts[1] + " " + logOutTimeParts[2] : "",
                            Comment = "Never delete this Archive"
                        }
        ).Distinct();
