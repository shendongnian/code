Namespace PrintQueueTool
    Public Interface IPrintJob
        Property JobId As Integer
        Property JobName As String
        Property JobOwner As String
    End Interface
End Namespace
Imports System.Collections.ObjectModel
Namespace PrintQueueTool
    Public Interface IPrinter
        Property Id As String
        Property IsDefault As Boolean
        Property IsLocal As Boolean
        Property Name As String
        Property ServerName As String
        Property ShareName As String
        Property PrintJobs As ObservableCollection(Of IPrintJob)
    End Interface
End Namespace
With the above objects, the viewmodel loads the printers into its collection of Printer objects as follows:
        Private Sub GetPrinters()
            Dim objScope = New ManagementScope(ManagementPath.DefaultPath)
            objScope.Connect()
            Dim selectQuery As SelectQuery = New SelectQuery With {.QueryString = "Select * from win32_Printer"}
            Using searcher = New ManagementObjectSearcher(objScope, selectQuery)
                Using moCollection = searcher.Get()
                    PrinterCollection = New ObservableCollection(Of IPrinter)
                    For Each mo As ManagementObject In moCollection
                        Dim newPrinter = New Printer(mo)
                        PrinterCollection.Add(newPrinter)
                    Next mo
                End Using
            End Using
        End Sub
The printer object builds its own properties and queue from the ManagementObject it is passed
        Public Sub New(managementObject As System.Management.ManagementObject)
         Contracts.Contract.Requires(managementObject IsNot Nothing)
         Id = Guid.NewGuid().ToString()
            Name = managementObject(NameOf(Name))
            IsDefault = CBool(managementObject("Default"))
            IsLocal = CBool(managementObject("Local"))
            Using srv As PrintServer = If((CBool(managementObject("Local"))), New LocalPrintServer(), New PrintServer(CStr(managementObject("serverName"))))
                Using queue As PrintQueue = srv.GetPrintQueue(If((CBool(managementObject("Local"))), CStr(managementObject(NameOf(Name))), CStr(managementObject("shareName"))))
                    PrintJobs = New ObservableCollection(Of IPrintJob)
                    Using jobs = queue.GetPrintJobInfoCollection()
                        For Each job In jobs
                            Dim printJob = New PrintJob With
                            {
                                .JobId = job.JobIdentifier,
                                .JobName = job.JobName,
                                .JobOwner = job.Submitter
                            }
                        Next
                    End Using
                End Using
            End Using
        End Sub
