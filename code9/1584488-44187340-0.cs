	[PXDBString(15, IsKey = true, IsUnicode = true, InputMask = ">CCCCCCCCCCCCCCC")]
	[PXDefault()]
	[PXUIField(DisplayName = "Reference Nbr.", Visibility = PXUIVisibility.SelectorVisible, TabOrder = 1)]
	[ARInvoiceType.RefNbr(typeof(Search2<AR.Standalone.ARRegisterAlias.refNbr,
		InnerJoinSingleTable<ARInvoice, On<ARInvoice.docType, Equal<AR.Standalone.ARRegisterAlias.docType>,
			And<ARInvoice.refNbr, Equal<AR.Standalone.ARRegisterAlias.refNbr>>>,
		InnerJoinSingleTable<Customer, On<AR.Standalone.ARRegisterAlias.customerID, Equal<Customer.bAccountID>>>>,
		Where<AR.Standalone.ARRegisterAlias.docType, Equal<Optional<ARInvoice.docType>>,
			And<AR.Standalone.ARRegisterAlias.origModule, Equal<BatchModule.moduleSO>,
			And<Match<Customer, Current<AccessInfo.userName>>>>>, 
		OrderBy<Desc<AR.Standalone.ARRegisterAlias.refNbr>>>), Filterable = true)]
	[ARInvoiceType.Numbering()]
	[ARInvoiceNbr()]
	protected virtual void ARInvoice_RefNbr_CacheAttached(PXCache sender)
	{
	}
