    public class Foo
    {
    public System.Threading.Timer EventTimer { get; set; }
    
    public Foo(){
    EventTimer = new System.Threading.Timer(new TimerCallback(Foo.DoCheck),
                                                                            this,
                                                                            this.TimingInterval,
                                                                            this.TimingInterval);
    
    }
    public void DoCheck(){ //do check here}
