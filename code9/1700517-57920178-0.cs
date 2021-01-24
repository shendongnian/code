public byte[] Avatar { get; set; }
var avatar =  File.ReadAllBytes(filePath);
  2.use your machine as a file server and store the path of your file in database :
public string Avatar { get; set; }
In my Opinion the second way is better and i always use this pattern but it depends on your machine's H.D.D and the amount of files you want to store.   
