    // using System.Web.Script.Serialization;
    var ser = new JavaScriptSerializer();
    var one = ser.Serialize(new One() { Id = 1, Name = "George" });
    
    Console.WriteLine(one);
