            while (await call.ResponseStream.MoveNext())
            {
                //
                // Use the dispatcher to invoke below onto the UI thread.
                this._someUiControl.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    // Do UI stuff inside this scope 
                }));
            }
