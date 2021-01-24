    public void BeforeSendReply {
        ... gather Request data.
        using (var conn = new SqlConnection(...)) {
            ... Log using ADO.NET
        }
    }
