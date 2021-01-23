    Task.Run(() =>
            {
                while (...)
                {
                    //...
                    //Update guages
                    GBase.Dispatcher.Invoke(() =>
                    {
                        GBase.Scales[0].Needles[0].Value = Math.Round(ActualJointPosition[0] * (180.0 / Math.PI));
                        Debug.WriteLine(DateTime.Now + " " + GBase.Scales[0].Needles[0].Value);
                    });
                    //..
                }
            }).ContinueWith(
            (t) =>
            {
                Vrep.SimGetJointPositionEnd(ClientId, JointHandles[0]);
                Vrep.SimGetJointPositionEnd(ClientId, JointHandles[1]);
                Vrep.SimGetJointPositionEnd(ClientId, JointHandles[2]);
                Vrep.SimGetJointPositionEnd(ClientId, JointHandles[3]);
                MoveJointsButton.IsEnabled = true;
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
