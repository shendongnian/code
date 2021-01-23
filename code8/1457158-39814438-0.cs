    public ViewClass GetMessages()
    {
        PrincelysDataContext pData = new PrincelysDataContext();
        Princelys.Models.ViewClass myViewList =new ViewClass();
        var myMessage =from r in pData.Messages select r;
        DateTime presentTime = new DateTime();
        foreach (var myValues in myMessage)
        {
            myViewList.myMessage.Add(new ViewClass
            {
                CreatedName ="ffff",// (from m in pData.Users where m.userid == myValues.createdBy select m.userName).Single(),
                Messages = myValues.Message,
                CreateOn = myValues.createddatetime.Subtract(presentTime)
            });
        }
        return myViewList;
    }
