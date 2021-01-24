    public void DetailsInitial(long Id)
    {
        Details<InitialDetailsViewModel, InitialStandard>(orderId);
    }
    public void DetailsAltered(long Id)
    {
        Details<AlteredDetailsViewModel, AlteredStandard>(orderId);
    }
    public ActionResult Details<T, U>(long Id) 
        where T : DetailsViewModel<U> 
        where U : Standard
    {
        var model = Mapper.Map<T>(order);
        return model;
    }
