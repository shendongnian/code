    async void TrueAsyncCallFunc()
        {
            try{
                await AsyncFunc();
                //doSomething
            }
            catch(Exception){
                throw;
            }
            finally{
                //do last operation
            }
        }
