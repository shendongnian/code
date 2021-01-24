    interface IResult{}
    public class Success:IResult{}
    public class Stopped { 
        public int Frame{get;}
        Stopped(int frame) { Frame=frame; }
    }
    ....
    var result=await Run(...);
    switch (result)
    {
        case Success _ : 
            Console.WriteLine("Finished");
            break;
        case Stopped s :
            Console.WriteLine($"Stopped at {s.Frame}");
            break;
    }
