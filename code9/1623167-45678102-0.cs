    public class Process : Component {
        //
        // FIELDS
        //
 
        bool haveProcessId;
        int processId;
        bool haveProcessHandle;
        SafeProcessHandle m_processHandle; // <- This should be disposed
        bool isRemoteMachine;
        string machineName;
        ProcessInfo processInfo;
        Int32 m_processAccess;
    ...
