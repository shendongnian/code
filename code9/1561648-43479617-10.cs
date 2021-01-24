      <system.serviceModel>
        <services>
          <service name="StackOverflow.Wcf.Services.ClientConnectionService">
            <endpoint
               address="net.tcp://localhost:9988/ClientConnectionService/"
                binding="netTcpBinding"
                contract="StackOverflow.Wcf.Services.Contracts.IClientConnectionService"
              ></endpoint>
          </service>
        </services>
      </system.serviceModel>
