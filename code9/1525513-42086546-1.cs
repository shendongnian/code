    <%@ Import Namespace="System.Diagnostics" %>
    <%@ Import Namespace="System.Reflection" %>
    <%
        String assembly = Assembly.GetExecutingAssembly().Location;
        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo( assembly );
        String version = versionInfo.FileVersion?.Replace(".", "") ?? "someFallbackValue";
    %>
    ...
    
    <script src="/MyViewCore.js?v=<%: version %>" type="text/javascript"></script>
