    public static void StartSaveOperationAsync(MyBigObject myObjectToSave)
    {
        var targetQueue = new MessageQueue(".\private$\pendingSaveOperations");
        var message = new Message(myObjectToSave);
        targetQueue.Send(message);
    }
