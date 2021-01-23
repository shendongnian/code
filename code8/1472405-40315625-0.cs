    public async Task<ApiResponseDto> DBHelper(Func<DbContext,Task<ApiResponseDto>> apiRes) // differing parameters
    {
        try // repeated
        {
            using (var db = new DbContext()) // repeated
            {
                // do stuff - this is where the unique stuff is
                var result = await apiRes(db);
                return result;
            }
        }
        catch (Exception e)
        { // repeated
            HandleServiceLayerException();
            return null;
        }
    }
