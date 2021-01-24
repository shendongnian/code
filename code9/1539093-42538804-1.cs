    var status = new List<Status> {
                    new Status { StatusId=1, StatusName="A" },
                    new Status { StatusId=2, StatusName="B" },
                    new Status { StatusId=3, StatusName="C" },
                    new Status { StatusId=4, StatusName="D" },
    };
    
    var result = status.FirstOrDefault(x => x.StatusName.Equals("A", StringComparison.InvariantCulture));
    
    if(result!=null)
    {
        ViewBag.StatusId = new SelectList(result, "StatusId", "StatusName");
    }
