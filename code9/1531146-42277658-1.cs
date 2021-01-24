    public interface IWrapThirdParty {
      void ThirdPartyMethodOne(); 
      int ThirdPartyMethodTwo();
    }
     public class ThirdPartyV1Wrapper : IWrapThirdParty {
      public void ThirdPartyMethodOne() {
        ThirdPartyV1 obj = new ThirdPartyV1();
        obj.ThirdPartyMethodOne();
      }
      public int ThirdPartyMethodTwo(){
        ThirdPartyV1 obj = new ThirdPartyV1();
        return obj.ThirdPartyMethodTwo();
      }
    }
