    public ResponseList<Model> GetData( string ta_id ) {
                ResponseList<Model> response = new ResponseList<Model>();
                List<Model> res = null;
                try
                {
                    res = new List<Model>();
                    //perform your operations
                    res.data = responselist;
                }
                catch (Exception ex)
                {
                    HandleResponse.AddException(ex, ref response);
                }
                response.DataList = res;
                return response;
            }
