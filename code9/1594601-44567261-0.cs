    private static SempahoreSlim _mutex = new SemaphoreSlim(1);
    public static async Task<CommonResult<IEnumerable<AttendanceDTO>>> DownloadAttendanceAsync(string selectedDate, int siteId)
    {
      await _mutex.WaitAsync();
      try
      { 
        ...
      }
      catch (Exception e)
      {
        return new CommonResult<IEnumerable<AttendanceDTO>> { IsSuccess = false, Data = null, ErrorMessage = "Download Error" };
      }
      finally
      {
        _mutex.Release();
      }
    }
