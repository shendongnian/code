    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
      <typeAliases>
        <typeAlias alias="IFacadeReaderService" type="Interfaces.Services.IFacadeReaderService, Interfaces" />
        <typeAlias alias="FacadeReaderService" type="Services.FacadeReader.FacadeReaderService, Services" />
        
        <typeAlias alias="ILoggerService" type="Interfaces.Services.ILoggerService, Interfaces" />
        <typeAlias alias="LoggerService" type="Services.Log.LoggerService, Services" />
        
        
        <typeAlias alias="IBal" type="Interfaces.Bal.IBal, Interfaces" />
        <typeAlias alias="BusinessManager" type="Bal.BusinessManager, Bal" />
        
       
      </typeAliases>
        <container>
          <register type="IFacadeReaderService" mapTo="FacadeReaderService" name="FRS"/>
          <register type="ILoggerService" mapTo="LoggerService" name="LS"/>
          <register type="IBal" mapTo="BusinessManager" name="BMS">
            <constructor>
              <param name="facadeReaderService">
                <dependency name="FRS" />
              </param>
              <param name="loggerService">
                <dependency name="LS" />
              </param>
            </constructor>
          </register>
        </container>
    </unity>
