    public IEnumerable<UModel.Form> GetForms(string formName)
    {
    	using (var context = new UASContext())
        {
    		var query = from form in context.Forms
    			join formCode in context.FormCode on form.FormCodeID equals formCode.FormCodeID
    			where form.Active == true and formCode.FormName == formName
    			select form;
    
    		return query.ToList();
    	}
    }
