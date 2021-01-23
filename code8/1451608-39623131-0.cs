            static void Main(string[] args)
        {
            DataCls dataCls = new DataCls();
            string Message = "[AE][1W] Message:sample message Priority:Info Time:Sep 21 2016  1:13PM Tag:/abc/pqr/xyz";
            dataCls.Message = Message.Substring(Message.IndexOf("Message:")+8);
            dataCls.Message = dataCls.Message.Substring(0, dataCls.Message.LastIndexOf("Priority"));
            dataCls.Priority = Message.Substring(Message.IndexOf("Priority:")+9);
            dataCls.Priority = dataCls.Priority.Substring(0,dataCls.Priority.LastIndexOf("Time"));
            string Time = Message.Substring(Message.IndexOf("Time"));
            Time = Time.Substring(0, Time.LastIndexOf("Tag"));
            dataCls.Time = Convert.ToDateTime(Time.Substring(Time.IndexOf(":")+1));
            dataCls.Tag = Message.Substring(Message.IndexOf("Tag:")+4);
            dataCls.Tag = dataCls.Tag.Substring(0);
        }
