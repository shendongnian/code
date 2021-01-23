    private TokenModel GetToken()
            {
                TokenModel result = null;
    
                if (this._systemState.HasValidToken(this._currentDateTime) )
                {
                    result = this._systemState.RetrieveUserData().TokenData;
                }
                else
                {
                    try
                    {
                        result = this._portalApiWrapperBase.RequestAccessTokenData();
                    }
                    catch(Exception ex)
                    {
                        this.LastErrorMessage = ex.Message;
                    }
                    finally
                    {
                        this._systemState.AddTokenData(result);
                    }
                }
    
                return result;
            }
