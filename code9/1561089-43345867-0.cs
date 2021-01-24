    using System.Linq;
    // ..
    public void LoadData() 
    {
        // guessing you will implementing an identifier later..
        var currentActor = SaveData.actorContainer.First();
        transform.position = currentActor.pos;
       
        // also set the loaded data to the field
        data = currentActor;
    }
    // ..
