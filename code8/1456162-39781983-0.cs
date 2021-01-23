    public async Task SomeMethod() {
        //code in method.
        var _myRepo = new repo();
        var someParameterRequired = 1;
        var process = await RepeatableMasterPiece(1, 2, () => _myRepo.IsCustomerComplete(someParameterRequired));
        //do something with process result
    }
    private async Task<bool> RepeatableMasterPiece(int param1, int param2, Func<Task<bool>> method) {
        int retry = 0;
        bool soapComplete = false;
        string soapFault = "just a placeholder for example";
        bool blackListStatus = false;
        while (!soapComplete && retry <= 1) {
            try {
                if (soapFault != null) {
                    //do some stuff with param1 & param2 here
                }
                if (!soapComplete && method != null) {
                    return await method();
                }
            } catch (FaultException ex) {
                soapFault = ex.Message;
                retry++;
                if (retry > 1) {
                    throw ex;
                }
            }
        }
        return false;
    }
