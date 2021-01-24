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
    <add name="System.Net" value="Verbose" />
    <add name="System.Net.Sockets" value="Verbose" />
  </switches>
</system.diagnostics>
This is the best I can do with the information in the question and I hope that this helps.
EDIT: After posting the results, it looks like the call is trying to negotiate a TLS 1.0 connection, which the server does not support. I've put the details in a comment below.
