    public class Temp
    {
      public string firstNumber{ get;set;}
      public decimal secondNumber{ get;set;}
      public decimal sum{ get;set;}
    }
    
    var resultDTO = JsonConvert.DeserializeObject<Temp>(result);
