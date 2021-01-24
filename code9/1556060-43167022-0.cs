     [System.Security.SecuritySafeCritical]  // auto-generated
            public Thread(ThreadStart start) {
                if (start == null) {
                    throw new ArgumentNullException("start");
                }
                Contract.EndContractBlock();
                SetStartHelper((Delegate)start,0);  //0 will setup Thread with default stackSize
            }
