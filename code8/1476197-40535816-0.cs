    HtmlForm f02Submit = PageDecla.Forms[1];
    HtmlSubmitInput SubM02 = (HtmlSubmitInput)PageDecla.GetElementsByName("SUBMIT")[1];
    f02Submit.AppendChild(SubM02);
    var count = f02Submit.ChildElementCount;
    SubM02 = (HtmlSubmitInput)f02Submit.ChildNodes[count-1];
    PaginaDecla = (HtmlPage)SubM02.Click();
    f02Submit = null;
    SubM02 = null;
    int f = 0, hfImp = 0;
    f = PaginaDecla.Forms.Count;
    
                
    for (int i = 0; i < f; i++)
    {
    	var form = PageDecla.Forms[i];
    	hfImp = form.ChildElementCount;
    	SubM02 = (HtmlSubmitInput)PageDecla.GetElementsByName("SUBMIT")[i];
    	for (int j = 0; j < hfImp; j++)
    	{                    
    		var hfI = (HtmlHiddenInput)form.ChildNodes[j];
    		var nameHF = hfI.NameAttribute;
    		var val = hfI.ValueAttribute;
    		if ((val == cod_int) && (nameHF == name))
    		{
    			form.AppendChild(SubM02);
    			hfImp = form.ChildElementCount;
    			var btn = (HtmlSubmitInput)form.ChildNodes[hfImp-1];
    			PageDecla = (HtmlPage)btn.Click();
    			j = hfImp;
    			i = f;
    		}
    
    
    	}
    }
