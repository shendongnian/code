    interface IMyInterface
    {
        public int QualificationId {get;}
        public int ProductId {get;}
    }
    public void MyFunct<T>(List<T> objectList) where T: IMyInterface
    {
        // here you know that any T implements IMyInterface,
        // and thus you can get QualificationId and ProductId
         List<T> list = objectList
            .Where(listElement => listElement.QualificationID == setName).ToList();
        redisClient.SetAdd<string>("Qualification:" + setName, 
            list.Select(listElement => listElement.ProductID).ToString());
    }
