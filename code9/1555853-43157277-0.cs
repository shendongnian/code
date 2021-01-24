    if (a.STUDENTNAME != "" && a.COURSEID != null && a.TEACHERID != null && a.PHOTOID != null)
    {
	    var TU = db.Students.FirstOrDefault(p => p.STUDENTID == a.STUDENTID);
	    if (TU != null)
	    {
		    TU.STUDENTNAME = a.STUDENTNAME;
		    TU.COURSEID = a.COURSEID;
		    TU.TEACHERID = a.TEACHERID;
		    TU.PHOTOID = a.PHOTOID;
		    db.Students.Update(TU);
	    }
	    else
	    {
		    TU = new Student();
		    TU.STUDENTID = a.STUDENTID;
		    TU.STUDENTNAME = a.STUDENTNAME;
		    TU.COURSEID = a.COURSEID;
		    TU.TEACHERID = a.TEACHERID;
		    TU.PHOTOID = a.PHOTOID;
		    db.Students.Add(TU);
	    }
		
        db.SaveChanges();
    }
