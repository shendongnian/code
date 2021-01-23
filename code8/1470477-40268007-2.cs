    public class StringSlice()
    {
         public Str {get;}
         public Index {get;}
         public StringSlice(string str, int index)
             {
                  this.Str = str;
                  this.Index = index;
             }
         public static List<string> ReconstructString(IEnumerable<StringSlice> parts)
             {
                  //Sort input by index return list with new strings in order. Probably have to use a buffer on the disc so as not to breach 2GB obj limit.
             }
    }
