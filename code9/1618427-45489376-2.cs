    Imports System.IO
    
    Public Class StreamWatcher
        Private Const MaxProgressEventsPerSecond As Integer = 200
        Private Property _Stream As Stream
        Private Property _PreviousPosision As Long
        Public ReadOnly Property StreamPosition As Long
            Get
                If IsNothing(_Stream) Then
                    Return 0
                Else
                    Return _Stream.Position
                End If
            End Get
        End Property
        Public ReadOnly Property StreamLength As Long
            Get
                If IsNothing(_Stream) Then
                    Return 0
                Else
                    Return _Stream.Length
                End If
            End Get
        End Property
        Private Property _TimeStarted As DateTime? = Nothing
        Private Property _TimeFinished As DateTime? = Nothing
        Public ReadOnly Property SecondsTaken As Double
            Get
                If IsNothing(_TimeStarted) Then
                    Return 0.0
                Else
                    If IsNothing(_TimeFinished) Then
                        Return (DateTime.Now - _TimeStarted.Value).TotalSeconds
                    Else
                        Return (_TimeFinished.Value - _TimeStarted.Value).TotalSeconds
                    End If
                End If
            End Get
        End Property
        Private Property _UpdatesCalled As Integer = 0
        Public ReadOnly Property Updates As Integer
            Get
                Return _UpdatesCalled
            End Get
        End Property
        Private Property _Progress As IProgress(Of EventType)
        Private Enum EventType
            Progressed
            Completed
        End Enum
        Public Event Progressed()
        Public Event Completed()
    
        Public Sub Watch(ByRef StreamToWatch As Stream)
            Reset()
            _Stream = StreamToWatch
            Dim ProgressHandler As New Progress(Of EventType)(Sub(Value) EventRaiser(Value))
            _Progress = TryCast(ProgressHandler, IProgress(Of EventType))
            _TimeStarted = DateTime.Now
            Task.Run(Sub() MonitorStream())
        End Sub
    
        Private Sub MonitorStream()
            Do
                If _PreviousPosision <> StreamPosition Then
                    _PreviousPosision = StreamPosition
                    _Progress.Report(EventType.Progressed)
                    //limit events to max events per second
                    Task.Delay(1000 / MaxProgressEventsPerSecond).Wait()
                End If
            Loop Until (Not IsNothing(_Stream)) AndAlso (StreamPosition = StreamLength)
            _TimeFinished = DateTime.Now
            _Progress.Report(EventType.Completed)
        End Sub
    
        Private Sub EventRaiser(ByVal EventToRaise As EventType)
            Select Case EventToRaise
                Case EventType.Progressed
                    _UpdatesCalled += 1
                    RaiseEvent Progressed()
                Case EventType.Completed
                    _UpdatesCalled += 1
                    RaiseEvent Completed()
            End Select
        End Sub
    
        Private Sub Reset()
            _Stream = Nothing
            _PreviousPosision = 0
            _TimeStarted = Nothing
            _TimeFinished = Nothing
            _UpdatesCalled = 0
        End Sub
    
    End Class
