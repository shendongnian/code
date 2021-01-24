          private void _HidDevice_InputReportReceived(HidDevice sender, HidInputReportReceivedEventArgs args)
            {
                if (!_IsReading)
                {
                    lock (_Chunks)
                    {
                        var bytes = InputReportToBytes(args);
                        _Chunks.Add(bytes);
                    }
                }
                else
                {
                    var bytes = InputReportToBytes(args);
    
                    _IsReading = false;
    
                    _TaskCompletionSource.SetResult(bytes);
                }
    }
