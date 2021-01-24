        ...
        switch (originalState)
        {
            case CommunicationState.Created:
            case CommunicationState.Opening:
            case CommunicationState.Faulted:
                this.Abort();
                if (originalState == CommunicationState.Faulted)
                {
                    throw TraceUtility.ThrowHelperError(this.CreateFaultedException(), Guid.Empty, this);
                }
                break;
            ...
        }
        ...
    }
