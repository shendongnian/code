		/***************************************************************
		 *I'm not sure how you want to use the results still, 
		 *	so I'll just stick them in a Dictionary for this example.
		 *	***********************************************************/
		SortedDictionary<string, string> objLookupResults = new SortedDictionary<string, string>();
        // --- note how I added  /text()... doesn't change much, but being specific  <<<<<<
		var kschlResultList = docresult.SelectNodes("//root/CalculationLogCompact/CalculationLogRowCompact/KSCHL/text()");
		
		foreach (System.Xml.XmlText objNextTextNode in kschlResultList) {
            // get the actual text from the XML text node
			string strNextKSCHL = objNextTextNode.InnerText;
            // use it to make the XPath to get the INFO  ---  see the [KSCHL/text()= ...
			string strNextXPath = "//SNW5_Pricing_JKV-Q10_full/PricingProcedure[KSCHL/text()=\"" + strNextKSCHL + "\"]/INFO/text()";
            // and get that INFO text!  I use SelectSingleNode here, assuming only one INFO for each KSCHL.....  if there can be more than one INFO for each KSCHL, then we'd need another loop here
			string strNextINFO = docdata.SelectSingleNode(strNextXPath).InnerText;
			// --- then you need to put this result somewhere useful to you.
			//		I'm not sure what that is, so I'll stick it in the Dictionary object.
			objLookupResults.Add(strNextKSCHL, strNextINFO);
		}
