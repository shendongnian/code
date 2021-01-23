    <system.diagnostics>
        <trace autoflush="true"/>
        <sources>
          <source name="System.Net" maxdatasize="1024">
            <listeners>
              <add name="TraceFile"/>
            </listeners>
          </source>
          <source name="System.Net.Sockets" maxdatasize="1024">
            <listeners>
              <add name="TraceFile"/>
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add name="TraceFile" type="System.Diagnostics.TextWriterTraceListener"
            initializeData="trace.log"/>
        </sharedListeners>
        <switches>
          <add name="System.Net" value="Verbose"/>
          <add name="System.Net.Sockets" value="Verbose"/>
        </switches>
    </system.diagnostics>
