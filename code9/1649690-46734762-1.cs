    [HttpDelete]
    public async Task<IActionResult> DeleteAd(AdDTO model)
    {
        var command = new RemoveUserAd
        {
            AdId = model.Id,
            ....
        };
        await DispatcheAsync<RemoveUserAd>(command);
        return RedirectToAction("AllAds","UserAd");
    }
