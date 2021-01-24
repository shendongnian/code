    <system.serviceModel>
        <services>
          <service name="ExcelDataService.Services.ExcelDataService">
            <endpoint address="net.tcp://localhost:8887/ExcelDataService/"
                       binding="netTcpBinding"
                       contract="ExcelDataService. ServiceContracts.IExcelDataService"
                      ></endpoint>
          </service>
        </services>
      </system.serviceModel>
