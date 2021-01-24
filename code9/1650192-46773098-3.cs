    Action<Inquiry, InquirySummary> sumarize = new Action<Inquiry, InquirySummary>((i, sum) =>
    {
    	if (i.UpaValue == "y")
    		sum.y += 1;
    	else if (i.UpaValue == "n")
    		sum.n += 1;
    	else
    		sum.na += 1;
    });
