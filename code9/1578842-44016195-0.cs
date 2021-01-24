        BKQEventCustomData BKQEventData = BKQHelper.ParseBase64EventData(Server.UrlDecode(Request.Url.Query));
        var cutomData = JsonConvert.DeserializeObject<NopOrderData>(BKQEventData.custom.data.ToString());
        if (BKQEventData != null)
        {
            AuthenticateRequest(BKQEventData.xcm.clid, BKQEventData.xcm.opid);
            var model = _applicationService.CreateMyViewModel(BKQeventData);
        }
        else
        {
            return RedirectToActionPermanent("Login", "Login");
        }
        pubilc class MyApplicationService : IMyApplicationService
        {
            public CreateTaskEventViewModel(BKQeventCustomData)
            {
                var model = new TaskEventViewModel();
                var services =  _placesService.GetPlacesByClientId(BKQProfile.ClientId).Where(p => p.Active);
                var contractors = _contractorService.GetContractorsByClientId(BKQProfile.ClientId);
                var statuses = _statusService.GetStatusByClientId(BKQProfile.ClientId);
                return TaskEventViewModel.CreateFromBKQCustomData(model, serivces, contractors, statuses);
            }   
        }
        public class TaskEventViewModel
        {
            public static CreateFromBKQCustomData(BKQCustomData bKQCustomData, IEnumerable<Serivce> services, ...)
            {
                 var model = new TaskEventViewModel();
                 model.PlacesList = new SelectList(services, "PlaceId", "Name");
                 ...
                 model.TaskEvent = TaskEvent.CreateFromBKQEventData(model);
                 model.BKQContact = BKQFramework.Contact.GetById(BKQEventData.xcm.contid);
            }
        }
