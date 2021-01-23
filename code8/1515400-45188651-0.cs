    Imports System.Reflection.MethodBase
    Imports System.Data.SqlClient
    Imports System.IO
    
    Public Class frmThumbEnrol
        Implements DPFP.Capture.EventHandler
    
        Private Capturer As DPFP.Capture.Capture
        Delegate Sub FunctionCall(ByVal param)
    
        Private Event OnTemplate(ByVal template)
    
        Private Enroller As DPFP.Processing.Enrollment
        Public Sel_UsrID As String
    
        Public Enum Thumb
            Enrol
            Verify
        End Enum
        Public theModule As Thumb
    
        Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If theModule = Thumb.Enrol Then
                    Me.Text = "[ Thumb Impression - Enrol ]"
                    Me.btnSave.Visible = True
                    Me.btnClose.Text = "Cancel"
                Else
                    Me.Text = "[ Thumb Impression - Verify ]"
                    Me.btnSave.Visible = False
                    Me.btnClose.Text = "Close"
                End If
    
                Me.txtStatus.Clear()
                Me.PBoxThumb.Image = Nothing
                Me.lblCount.Text = ""
    
                Init()
    
                StartCapture()
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Public Overridable Sub Init()
            Try
    
                Capturer = New DPFP.Capture.Capture() 'create a capture operation.
                Enroller = New DPFP.Processing.Enrollment
    
                Me.lblCount.Text = IIf(theModule = Thumb.Enrol, "Fingerprint Samples Needed: " & Enroller.FeaturesNeeded.ToString, "")
    
                If (Not Capturer Is Nothing) Then
                    Capturer.EventHandler = Me 'capturing events.
                Else
                    MakeReport("Can't initiate capture operation!")
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Private Sub StartCapture()
            Try
    
                If (Not Capturer Is Nothing) Then
                    Capturer.StartCapture()
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        '------------------------------------------------------------------------------------------------------------------
        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Try
    
                StopCapture()
    
                Me.Close()
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Private Sub StopCapture()
            Try
    
                If (Not Capturer Is Nothing) Then
                    Capturer.StopCapture()
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        '------------------------------------------------------------------------------------------------------------------
        Private Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
            Try
    
                MakeReport("The fingerprint reader was connected.")
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
        Private Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
            Try
    
                MakeReport("The fingerprint reader was disconnected.")
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Private Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
            Try
    
                MakeReport("The fingerprint reader was touched.")
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
        Private Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
            Try
    
                MakeReport("The finger was removed from the fingerprint reader.")
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Private Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
            Try
    
                MakeReport("The fingerprint sample was captured.")
    
                If theModule = Thumb.Enrol Then
                    Process_Enrol(Sample)
                Else
                    Process_Verify(Sample)
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Private Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
            Try
    
                If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
                    MakeReport("The quality of the fingerprint sample is good.")
                Else
                    MakeReport("The quality of the fingerprint sample is poor.")
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        Private Sub MakeReport(ByVal status)
            Try
    
                Invoke(New FunctionCall(AddressOf _MakeReport), status)
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
        Private Sub _MakeReport(ByVal status)
            Try
    
                Me.txtStatus.AppendText(status + Chr(13) + Chr(10))
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        '------------------------------------------------------------------------------------------------------------------
        Protected Sub DrawPicture(ByVal bmp)
            Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
        End Sub
        Private Sub _DrawPicture(ByVal bmp)
            Me.PBoxThumb.Image = New Bitmap(bmp, Me.PBoxThumb.Size)
        End Sub
    
        Private Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
            Dim bitmap As Bitmap = Nothing
    
            Try
    
                Dim convertor As New DPFP.Capture.SampleConversion()
    
                convertor.ConvertToPicture(Sample, bitmap)
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
    
            Return bitmap
    
        End Function
    
        Private Function Extract_Features(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
            Try
    
                Dim extractor As New DPFP.Processing.FeatureExtraction()    ' Create a feature extractor
                Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
                Dim features As New DPFP.FeatureSet()
    
                extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
    
                If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
                    Return features
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
    
            Return Nothing
    
        End Function
    
        Protected Sub SetStatus(ByVal status)
            Try
    
                Invoke(New FunctionCall(AddressOf _SetStatus), status)
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
        Private Sub _SetStatus(ByVal status)
            Try
    
                Me.lblCount.Text = status
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        'Template Enrol
        Private Sub Process_Enrol(ByVal Sample As DPFP.Sample)
            Try
                DrawPicture(ConvertSampleToBitmap(Sample))
    
                Dim Features_Enrol As DPFP.FeatureSet = Extract_Features(Sample, DPFP.Processing.DataPurpose.Enrollment)
    
                If Not Features_Enrol Is Nothing Then 'Check quality of the sample if it's good
                    Try
                        MakeReport("The fingerprint feature set was created.")
                        Enroller.AddFeatures(Features_Enrol)
                    Finally
                        SetStatus("Fingerprint Templates Remaining: " & Enroller.FeaturesNeeded.ToString)
    
                        Select Case Enroller.TemplateStatus
                            Case DPFP.Processing.Enrollment.Status.Ready 'Report success and stop capturing
                                RaiseEvent OnTemplate(Enroller.Template)
                                StopCapture()
                                SetStatus("Fingerprint Templates Completed. Save now....")
    
                            Case DPFP.Processing.Enrollment.Status.Failed 'Report failure and restart capturing
                                Enroller.Clear()
                                StopCapture()
                                RaiseEvent OnTemplate(Nothing)
                                StartCapture()
                        End Select
                    End Try
                End If
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        'Template Verify
        Private Sub Process_Verify(ByVal Sample As DPFP.Sample)
            Try
    
                DrawPicture(ConvertSampleToBitmap(Sample))
    
                Dim Features_Verify As DPFP.FeatureSet = Extract_Features(Sample, DPFP.Processing.DataPurpose.Verification)
                Dim Verificator As New DPFP.Verification.Verification
                Dim result As New DPFP.Verification.Verification.Result()
    
                If Not Features_Verify Is Nothing Then 'Check quality of the sample if it's good
                    Dim fs As MemoryStream = New MemoryStream
                    Dim fs_bytes As Byte()
    
                    Dim obj As New cQryExec
                    Dim qry As String = "Select FingerImpr From [TableName] Where ID = '[PersonID]' And isThumb = 1"
                    Dim dset As New DataSet
    
                    dset = obj.ReturnDSet(qry)
    
                    If dset.Tables(0).Rows.Count > 0 Then
                        fs_bytes = dset.Tables(0).Rows(0).Item("FingerImpr")
                        fs = New IO.MemoryStream(fs_bytes)
    
                        Dim Saved_Template As New DPFP.Template(fs)
    
                        Verificator.Verify(Features_Verify, Saved_Template, result)
                    End If
    
                    If result.Verified Then
                        MakeReport("The fingerprint was VERIFIED.")
                    Else
                        MakeReport("The fingerprint was NOT VERIFIED.")
                    End If
                End If
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
        'Save -------------------------------------------------------------------------------------------------------------
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Try
    
                If Enroller.FeaturesNeeded > 0 Then
                    MessageBox.Show("'Insufficient Templates'." & vbCrLf & Enroller.FeaturesNeeded.ToString & "  more 'Fingerprint' scans needed.", MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
    
                Dim obj As New cQryExec
    
                Dim fs As MemoryStream = New MemoryStream
                Enroller.Template.Serialize(fs)
    
                fs.Position = 0
                Dim br As BinaryReader = New BinaryReader(fs)
                Dim fs_bytes() As Byte = br.ReadBytes(CType(fs.Length, Int32))
    
                Dim cmd As SqlCommand = New SqlCommand("Update [TableName] Set FingerImpr = @FingerImpr Where ID = '[PersonID]'", mycon)
                cmd.Parameters.Add("@FingerImpr", SqlDbType.Image).Value = fs_bytes
    
                If mycon.State = ConnectionState.Closed Then
                    mycon.Open()
                End If
    
                cmd.ExecuteNonQuery()
    
                If mycon.State <> ConnectionState.Closed Then
                    mycon.Close()
                End If
    
    
                MessageBox.Show("'Fingerprint' Templates Saved successfully.", MsgHeader, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnClose_Click("", System.EventArgs.Empty)
    
            Catch ex As Exception
                ErrMsg(ex, GetCurrentMethod.Name)
            End Try
        End Sub
    
    End Class
