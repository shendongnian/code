    [HttpDelete]
    public async Task<IActionResult> DeleteAd(Guid id)
    {
        var command = new RemoveUserAd
        {
            AdId = id,
            ....
        };
        await DispatcheAsync<RemoveUserAd>(command);
        return RedirectToAction("AllAds","UserAd");
    }
