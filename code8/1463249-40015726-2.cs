    public void OnTriggerEnter (Collider collider)
    {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SaveGame.dat");
           // Change here
           var obj = "This Will Be Serialized";
           bf.Serialize(file, obj); 
           file.Close();     
    }
