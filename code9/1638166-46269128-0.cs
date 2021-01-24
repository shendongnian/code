    <system.diagnostics>
        <sources>
          <source name ="System.ServiceModel" switchValue="Verbose">
            <listeners>
              <add name="xml" />
            </listeners>
          </source>
          <source name ="System.ServiceModel.MessageLogging" 
                  switchValue="Verbose, ActivityTracing">        
            <listeners>
              <add name="xml" />
            </listeners>
          </source>
          <source name ="System.Runtime.Serialization" switchValue="Verbose">
            <listeners>
              <add name="xml" />
            </listeners>
          </source>
       </sources>
       <sharedListeners>
          <add name="xml" type="System.Diagnostics.XmlWriterTraceListener"              
               traceOutputOptions="LogicalOperationStack" 
               initializeData="C:\log\WCFTrace.svclog" />
       </sharedListeners>
       <trace autoflush="true" />
      </system.diagnostics>
      <system.serviceModel>
        <diagnostics>
          <messageLogging 
               logEntireMessage="true" 
               logMalformedMessages="false"
               logMessagesAtServiceLevel="true" 
               logMessagesAtTransportLevel="false"/>
        </diagnostics>    
      </system.serviceModel>
