    if (!typedChar.Equals(char.MinValue) && char.IsLetterOrDigit(typedChar))
                {
                    if (m_session == null || m_session.IsDismissed) // If there is no active session, bring up completion
                    {
                        this.TriggerCompletion();
                        m_session.Filter();
                    }
                    else    //the completion session is already active, so just filter
                    {
                        m_session.Filter();
                    }
                    handled = true;
                }
