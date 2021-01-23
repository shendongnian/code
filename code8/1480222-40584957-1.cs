    _samedayServiceDescription = com_SubServiceDescriptionExtDS.COM_SubServiceDescriptionExt.Where(r => r.Description.Equals(samedayService)).FirstOrDefault().ServiceSubServiceId;
    _onedayServiceDescription = com_SubServiceDescriptionExtDS.COM_SubServiceDescriptionExt.Where(r => r.Description.Equals(onedayService)).FirstOrDefault().ServiceSubServiceId;
    _datedServiceDescription = com_SubServiceDescriptionExtDS.COM_SubServiceDescriptionExt.Where(r => r.Description.Equals(datedService)).FirstOrDefault().ServiceSubServiceId;
    _unpaidServiceDescription = com_SubServiceDescriptionExtDS.COM_SubServiceDescriptionExt.Where(r => r.Description.Equals(unpaidService)).FirstOrDefault().ServiceSubServiceId;
    _recallServiceDescription = com_SubServiceDescriptionExtDS.COM_SubServiceDescriptionExt.Where(r => r.Description.Equals(recallService)).FirstOrDefault().ServiceSubServiceId;
