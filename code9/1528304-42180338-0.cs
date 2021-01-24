    public static MessageBox Create(string message) {
       var newTimeBox = Instantiate(messageBox, penaltySpawnLoc.position, penaltyPrefab.transform.rotation, transform);
       var scr = newTimeBox.GetComponent<MessageBox>();
       scr.SetMessage(message);
       return scr;
