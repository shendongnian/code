    public static void SetActive(List<Element> list, string activeName) {
	    foreach (var e in list) {
		    if (e.Name == activeName || (e.SubElements != null && e.SubElements.Any(e1 => e1.Name == activeName)))
			    e.IsActive = true;
    		if (e.SubElements != null)
	    		SetActive(e.SubElements, activeName);
	    }
    }
