    Thread 55 - System ID 17820
    
    
    
    Entry point   clr!Thread::intermediateThreadProc 
    Create time   3/28/2017 9:51:46 AM 
    Time spent in user mode   0 Days 00:00:00.421 
    Time spent in kernel mode   0 Days 00:00:00.187 
    
    
    This thread is waiting on data to be returned from the database server
    
    The current executing command is : SELECT cfgid, cfgvalue FROM ae_cfg WHERE cfgid = 34 and the command timeout is set to 0 seconds. 
    
     The connection string for this connection : *** and the connection timeout : 15 seconds. 
    
    
    
    
    
    .NET Call Stack
    
    
    
    
    System_Data_ni!DomainNeutralILStubClass.IL_STUB_PInvoke(SNI_ConnWrapper*, SNI_Packet**, Int32)+84 
    [[InlinedCallFrame] (.SNIReadSyncOverAsync)] .SNIReadSyncOverAsync(SNI_ConnWrapper*, SNI_Packet**, Int32) 
    System_Data_ni!SNINativeMethodWrapper.SNIReadSyncOverAsync(System.Runtime.InteropServices.SafeHandle, IntPtr ByRef, Int32)+6a 
    System_Data_ni!System.Data.SqlClient.TdsParserStateObject.ReadSniSyncOverAsync()+83 
    System_Data_ni!System.Data.SqlClient.TdsParserStateObject.TryReadNetworkPacket()+7e 
    System_Data_ni!System.Data.SqlClient.TdsParserStateObject.TryPrepareBuffer()+65 
    System_Data_ni!System.Data.SqlClient.TdsParserStateObject.TryReadByte(Byte ByRef)+2e 
    System_Data_ni!System.Data.SqlClient.TdsParser.TryRun(System.Data.SqlClient.RunBehavior, System.Data.SqlClient.SqlCommand, System.Data.SqlClient.SqlDataReader, System.Data.SqlClient.BulkCopySimpleResultSet, System.Data.SqlClient.TdsParserStateObject, Boolean ByRef)+292 
    System_Data_ni!System.Data.SqlClient.SqlDataReader.TryConsumeMetaData()+5c 
    System_Data_ni!System.Data.SqlClient.SqlDataReader.get_MetaData()+66 
    System_Data_ni!System.Data.SqlClient.SqlCommand.FinishExecuteReader(System.Data.SqlClient.SqlDataReader, System.Data.SqlClient.RunBehavior, System.String)+11d 
    System_Data_ni!System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(System.Data.CommandBehavior, System.Data.SqlClient.RunBehavior, Boolean, Boolean, Int32, System.Threading.Tasks.Task ByRef, Boolean, System.Data.SqlClient.SqlDataReader, Boolean)+ba0 
    System_Data_ni!System.Data.SqlClient.SqlCommand.RunExecuteReader(System.Data.CommandBehavior, System.Data.SqlClient.RunBehavior, Boolean, System.String, System.Threading.Tasks.TaskCompletionSource`1, Int32, System.Threading.Tasks.Task ByRef, Boolean)+22a 
    System_Data_ni!System.Data.SqlClient.SqlCommand.RunExecuteReader(System.Data.CommandBehavior, System.Data.SqlClient.RunBehavior, Boolean, System.String)+62 
    System_Data_ni!System.Data.SqlClient.SqlCommand.ExecuteReader(System.Data.CommandBehavior, System.String)+ca 
    XtenderSolutions.UtilityLibrary.General.DbCommon.GetStringTypeFromDB(XtenderSolutions.Administration.Database.DbCommonEx)+1aa 
    XtenderSolutions.UtilityLibrary.General.DbCommon.Open()+11c 
    XtenderSolutions.CMData.CMConnection.Open()+a7 
    XtenderSolutions.CMData.CMCfgMgr.Load(XtenderSolutions.CMData.CMConnection, Int16)+55 
    XtenderSolutions.CMData.CMConnection.InitEAIHooks()+4f 
    XtenderSolutions.CMData.CMConnection.Init(System.String)+595 
    XtenderSolutions.CMData.CMConnection..ctor(XtenderSolutions.CMData.CMSession, System.String)+17b 
    XtenderSolutions.CMData.CMSession.get_Connection()+7e 
    XtenderSolutions.CMData.CMSession.Login(XtenderSolutions.Configuration.DataSourceConfig, System.String, System.String, System.Security.Principal.WindowsIdentity, System.String, Boolean)+46e 
