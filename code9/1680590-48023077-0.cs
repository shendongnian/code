    public List<CaseListEntry> GetCaseListEntries()
        {
            var CaseGridTrs = CaseListGrid.FindElements(By.XPath(".//tr"));
            var entryList = CaseGridTrs.Select(x =>
            {
                var CaseEntryTds 		= x.FindElements(By.XPath(".//td"));
				
				var ListNoElement       = GetElementOrNull(CaseEntryTds,0);
				var RegisterDateElement = GetElementOrNull(CaseEntryTds,1);
				var DocumentTypeElement = GetElementOrNull(CaseEntryTds,2);
				var RegisterNoElement 	= GetElementOrNull(CaseEntryTds,3);
                
				
				var RegisterDate 		= (RegisterDateElement != null)? RegisterDateElement.Text : "";
                var RegisterNo 			= (RegisterNoElement != null)? RegisterNoElement.Text : "";
                var ListNo 				= (ListNoElement != null) ? ListNoElement.FindElement(By.XPath(".//a")).Text : "";
				var DocumentType        = (DocumentTypeElement != null) ? DocumentTypeElement.Text : "";
				return new CaseListEntry
                {
                    ListNo = ListNo ,
                    RegDate = DateTime.ParseExact(RegisterDate, "dd.MM.yyyy",
                    CultureInfo.InvariantCulture),
                    DocumentType = DocumentType
                };
            }).ToList();
            return entryList;
        }
    public IWebElement GetElementOrNull(IList<IWebElement> CaseEntryTds, int elementAtPosition, int maxSeconds = 1) {
		IWebElement element = null;
		IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(maxSeconds));
		wait.Until(d => {
			try {
				element = CaseEntryTds.ElementAt(elementAtPosition);
				return element.Displayed;
			} catch (WebDriverTimeoutException) {
				return false;
			} catch (NoSuchElementException) {
				return false;
			}
		});
	  return element;
  }
