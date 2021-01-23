                    var chatbox = new DataTable();
            chatbox.Columns.Add("Image", typeof(string));
            chatbox.Columns.Add("Message", typeof(string));
            chatbox.Columns.Add("Time", typeof(DateTime));
            (from user in db.Users.AsEnumerable()
             join ch in db.ChatHistories.AsEnumerable()
                 on user.Userid equals ch.Senderid
             where ch.Senderid == userid && ch.Receiverid == receiverid || ch.Receiverid == userid && ch.Senderid == receiverid
             orderby ch.id
             select new
             {
                 Image = user.image,
                 Message = ch.message,
                 Time = ch.dateTime
             })
             .Aggregate(chatbox, (dt, r) => { dt.Rows.Add(r.Image, r.Message, r.Time); return dt; });
