    public abstract class CountryFactory {
      protected abstract CountryTypeHandler getCountryTypeHandler(String type);
    }
    
    public class USHandlerFactory{
      @Override
      protected USHandlerFactory getCountryTypeHandler(String type){
        if(type=="type1){
          return new USType1Handler();
        }
        else if(type=="type2"){
          return new USType2Handler();
        }
      }
    }
    public class UKHandlerFactory{
      @Override
      protected UKHandlerFactory getCountryTypeHandler(String type){
        if(type=="type1){
          return new UKType1Handler();
        }
        else if(type=="type2"){
          return new UKType2Handler();
        }
      }
    }
    public void YourExecutingClass {
      USHandlerFactory handler; // Since this is your handler interface, it can hold any type of handler. You don't need to instantiate all your handlers. 
      
      String country = "us"; // Both country and type are input and can vary anyway you handle
      String type = "type1"; 
      CountryFactory factory;  
      if(country=="us"){
        factory = new USHandlerFactory();
      } else if(country=="uk") {
        factory = new UKHandlerFactory();
      }else{
        throw exception("unknown country");
      }
      handler = factory.getCountryTypeHandler(type);
      handler.Execute();
    }
