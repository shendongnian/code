    public class TestClass	{
       public class ProgressEventArgs : EventArgs {
    		public int Value { get; set; }
       }
       public event EventHandler<ProgressEventArgs> Progress;
       public void myLoop() {
    		for (int i = 0; i <= 1000; ++i) {
    			var evt = Progress;
    			if (evt != null) {
    				evt.Invoke(this, new ProgressEventArgs() { Value = i; });
    			}
    		}
       }
    }
