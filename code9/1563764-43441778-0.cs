    async Task<ResponseType> SafeAwaitResult(Task<ResultType> task)
    {
        try
        {
            ocrResult = await task;
            // do something to return a "success" value for ResponseType
        }
        catch (FailedToProcessException failedEx)
        {
            _logger.AddLog("OCRController->GetTextAsync", $"Failed to process exception: '{failedEx.ErrorMessage}'", LogLevel.ERROR);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, failedEx.ErrorMessage);
        }
        catch(InternalServerErrorException intEx)
        {
            _logger.AddLog("OCRController->GetTextAsync", $"Internal server error exception: '{intEx.ErrorMessage}'", LogLevel.ERROR);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, intEx.ErrorMessage);
        }
        catch (Exception e)
        {
            _logger.AddLog("OCRController->GetTextAsync", $"Exception: '{e.Message}'", LogLevel.ERROR);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "File can't be processed");
        }
    }
