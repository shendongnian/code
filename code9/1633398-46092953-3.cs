        public PartialViewResult CustomerChanged(int CustomerId)
        {
            var localizations = db.Localizations.Where(i => i.CustomerId == CustomerId).ToList();
            var Devices = (from d in db.Devices
                           select new DevicesToFiscalizationViewModel()
                           {
                               DeviceId = d.DeviceId,
                               DeviceName = d.Name,
                               SerialNumber = d.SerialNumber,
                           }).ToList();
            foreach (var item in Devices)
            {
                item.Localizations = localizations;
            }
            var fsc = new FiscalizationViewModel();
            fsc.Devices = Devices;
            return PartialView("~/Views/Fiscalizations/EditorTemplates/DevicesToFiscalizationViewModel.cshtml", fsc);
        }
