    using System;
    
    namespace YourNamespace {
      class StringA {
    
        private string privateVal = "";
        public string PublicVal {
          get {
            return this.privateVal;
          }
          set {
            this.privateVal = value;
          }
        }
        public StringA(char x, int y) {
          string res = "";
          string ConvertedChar = Convert.ToString(x);
    
          for (int i = 0; i < y; i++) {
            res += ConvertedChar;
          }
          // How to return string res?
          this.privateVal = res; //assign res to your accessor
        }
    
      }
      class MainClass {
        static void Main() {
          //then you can access the public property
          Console.WriteLine(new StringA('B', 15).PublicVal);
        }
      }
    }
