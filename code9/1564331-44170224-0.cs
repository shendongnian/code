    private void WaitChangeStatus(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                SmartCardErrorCode result;
                // Obtain a lock when we use the context pointer, which may be modified in the Dispose() method.
                lock (this)
                {
                    if (!this.HasContext)
                    {
                        return;
                    }
                    // This thread will be executed every 1000ms. 
                    // The thread also blocks for 1000ms, meaning 
                    // that the application may keep on running for 
                    // one extra second after the user has closed the Main Form.
                    result = (SmartCardErrorCode)UnsafeNativeMethods.GetStatusChange(this.context, 1000, this.states, (uint)this.states.Length);
                }
                if ((result == SmartCardErrorCode.Timeout))
                {
                    // Time out has passed, but there is no new info. Just go on with the loop
                    continue;
                }
                else if (result != SmartCardErrorCode.Succeeed)
                {
                    // TODO OnExceptionRaised
                    continue;
                }
                for (int i = 0; i <= this.states.Length - 1; i++)
                {
                    // Check if the state changed from the last time.
                    if ((this.states[i].EventState & CardState.Changed) == CardState.Changed)
                    {
                        // Check what changed.
                        SmartCardState state = SmartCardState.None;
                        if ((this.states[i].EventState & CardState.Present) == CardState.Present
                            && (this.states[i].CurrentState & CardState.Present) != CardState.Present)
                        {
                            // The card was inserted.                            
                            state = SmartCardState.Inserted;
                        }
                        else if ((this.states[i].EventState & CardState.Empty) == CardState.Empty
                            && (this.states[i].CurrentState & CardState.Empty) != CardState.Empty)
                        {
                            // The card was ejected.
                            state = SmartCardState.Ejected;
                        }
                        if (state != SmartCardState.None && this.states[i].CurrentState != CardState.Unaware)
                        {
                            SmartCardEventArgs args = new SmartCardEventArgs();
                            args.Manager = this;
                            switch(state)
                            {
                                case SmartCardState.Inserted:
                                {
                                    // Checa o ATR para monitorar apenas DESFire EV1
                                    if (OnCardInserted != null)
                                    {
                                        // Obtém o ATR
                                        byte[] atr = this.GetAtr(this.states[i].ATRBytes, this.states[i].ATRLength);
                                        
                                        // Cria SmartCard object and associa ao EventArgs
                                        SmartCard card = new SmartCard(atr);
                                        args.Card = card;
                                        // Dispara Evento
                                        OnCardInserted(this, args);
                                    }
                                    break;
                                }
                                case SmartCardState.Ejected:
                                {
                                    if (OnCardRemoved != null)
                                    {
                                        OnCardRemoved(this, args);
                                    }
                                    break;
                                }
                                default:
                                {
                                    // TODO Log
                                    // Null to force Garbage Collection
                                    args = null; 
                                    break;
                                }
                            }
                        }
                        //Update the current state for the next time they are checked.
                        this.states[i].CurrentState = this.states[i].EventState;
                    }
                }
            }
        }
