    using System;
    using System.Text;
    using System.Threading;
    
    public class Test {
    
     private static long secret = 0xdeadbeef;
     private static int digits = 6;
     private static int period_size_in_seconds = 1;
    
     public string phonenumber;
     public int validperiods;
    
     private string reference(long delta) {
      // get current minute (UTC)
      long now = DateTime.Now.ToUniversalTime().ToFileTimeUtc();
      now /= (period_size_in_seconds * 10000000);
      // factor in phone number
      var inputBytes = Encoding.ASCII.GetBytes(phonenumber);
      long mux = 0;
      foreach(byte elem in inputBytes) {
        mux ^= elem;
        mux <<= 1;
       }
       // limit number of digits
      long mod = Convert.ToInt64(Math.Pow(10, digits)) - 1; // how many digits?
      // apply time shift for validations
      now -= delta;
      // and play a little bit
      now *= mux; // factor in phone number
      now ^= secret; // play a bit
      now >>= 1; // with the number
      if (0 != (now & 0x1)) { // to make the code 
       now >>= 1; // read about LFSR to learn more
       now ^= secret; // less deterministic
      }
      now = Math.Abs(now);
      now %= mod; // keep the output in range
      return now.ToString().PadLeft(digits, '0');
     }
    
     public string getTimeVariable() {
      return reference(0);
     }
    
     public bool verifyVariable(string variable) {
      for (int i = 0; i < validperiods; i++) {
       if (variable == reference(i)) {
        return true;
       }
      }
      return false;
     }
    
     public void test() {
      phonenumber = "+48602171819";
      validperiods = 900;
      string code = getTimeVariable();
      
      if (verifyVariable(getTimeVariable()))
       System.Console.Write("OK1");
      
      if (verifyVariable(code))
       System.Console.Write(" OK2");
      
      Thread.Sleep(2*1000*period_size_in_seconds);
      
      if (verifyVariable(code)) {
       System.Console.WriteLine(" OK3");
      }
      
      System.Console.WriteLine(code);
     }
     
     public static void Main() {
      (new Test()).test();
     }
    }
