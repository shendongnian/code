    byte[] bytes = Encoding.Default.GetBytes(de.Properties["objectSid"].value);
    sidByte= Encoding.UTF8.GetString(bytes);
     
    Console.WriteLine("Object Sid: " + sidByte ); //Here is the changement 
 
