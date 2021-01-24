    private SemaphoreSlim _throttle = new SemaphoreSlim(20);
    private async Task UpdateUserProfilePercentageAsync(User user)
    {
      await _throttle.WaitAsync();
      try
      {
        user.ProfilePercentage = await UserAlgorithm.CalculatePercentage(user.Id);
      }
      finally { _throttle.Release(); }
    }
