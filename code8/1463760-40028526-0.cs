    [HttpPost]
    [Route("/api/SendMessage")]
    public void SendMessage([FromBody]string msg)
    {
        MessageBox MsgBox = new MessageBox();
        MsgBox.AddMsgToMsgBox(msg);
    }
