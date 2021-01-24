    <system.diagnostics>
      <trace autoflush="true" />
      <sources>
        <source name="System.Net" maxdatasize="1024">
          <listeners>
            <add name="MyTraceFile"/>
            <add name="MyConsole"/>
          </listeners>
        </source>
      </sources>
      <sharedListeners>
        <add name="MyTraceFile" type="System.Diagnostics.TextWriterTraceListener" initializeData="System.Net.trace.log" />
        <add name="MyConsole" type="System.Diagnostics.ConsoleTraceListener" />
      </sharedListeners>
      <switches>
        <add name="System.Net" value="Information" />
      </switches>
    </system.diagnostics>
