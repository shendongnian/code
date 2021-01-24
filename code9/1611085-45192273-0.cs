    public class PriceSchedule {
       public string Name {get; set;} // just an example, propert names depend on your json
       ...
    }
    [HttpPost]
    public void GetSchedule([FromBody] PriceSchedule priceScheduleObject)
    { /
    
