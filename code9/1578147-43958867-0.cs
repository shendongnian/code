        public ICommand SaveProfile
        {
            get
            {
                return new MvxCommand(async () =>              // async added
                {
                    if (_profile.IsValidData())
                    {
                        // Wait for task to compelte, do UI updates here
                        // TODO Throbber / Spinner
                        EnumWebServiceResult taskResult;
                        await Mvx.Resolve<IProfileWebService>().SendProfileToServer(_profile).ConfigureAwait(false);         // await, confi.. added
    
                        if(_profileWebService.getLastResponseResult() == true){
                            taskResult = EnumWebServiceResult.SUCCESS;
                        }else{
                            taskResult = EnumWebServiceResult.FAILED_UNKNOWN;
                        }
                        //_profileWebService.SendProfileToServer(_profile).Wait();
                        // Close(this);
                    }
                });
            }
        }
----
        private async Task Sleep()                                 // async added
        {
            return await Task.Delay(3000).ConfigureAwait(false);   // await, confi... added
        }
        public async Task SendProfileToServer(Profile profileObject)
        {
            // Validate arguments before attempting to use web serivce
            if (profileObject.IsValidData())
            {
                // TODO: Return ENUM FLAG that represents the state of the result
                await Sleep().ConfigureAwait(false);                      // await, confi... added
                lastResult = true;
            }else{
                lastResult = false;
            }
        }
