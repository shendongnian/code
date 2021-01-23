    //C# controller
    //You also need to inherit your controller from ApiConroller 
    // public class MyController : ApiConroller {//the code...}
      public void updcomson(string Id, string upddate, string updcomname, string updbrandname, string updzone, string updlocation, string updstartime, string updendtime, string updprogram, string updvenue, string updvenuename, string pm, string pax)
    {
      try{
        //do work...
        return OK(myResult);
      }
      catch(){
       return NotFound();
      }
    }
