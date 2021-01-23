	//CloneJson is the extension method from above - Deep copy
    var oldAgreement = agreement.CloneJson();
    
    var document = client.GetThirdPartyAgreement(agreement.AgreementDocumentId);
    
    UpdateDocument(agreement, document);
	var agreementString = Newtonsoft.Json.JsonConvert.SerializeObject(agreement, new CustomDateTimeConverter());
    var oldAgreementString = Newtonsoft.Json.JsonConvert.SerializeObject(oldAgreement, new CustomDateTimeConverter());
	
    if (agreementString != oldAgreementString)
    {
        agreementRepository.Update(agreement);
    }
	
	
