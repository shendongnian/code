    public void saveMember()
    {
    
      string pathMemberPk = Path.Combine(Environment.CurrentDirectory, @"../memberDataPk.bin");
    
      if (!File.Exists(pathMemberPk)) {
    
         memberPk = 0001;
         memberPkString = memberPk.ToString();
    
         IFormatter formatter = new BinaryFormatter();
         Stream streamPk = new FileStream(pathMemberPk, FileMode.Create);
         formatter.Serialize(streamPk,this.memberPkString);   
    
       }else{
    
         using (FileStream streamIn = File.OpenRead("f://MyFile.bin"))
         {
             IFormatter formatter = new BinaryFormatter();                   
             object obj = formatter.Deserialize(streamIn);
             memberPk = Convert.ToInt32(obj); //to INT
            memberPk = Convert.ToString(obj); //To String
    
             Console.WriteLine(memberPk);
          }
    
       }
    }
