        gallery.on("item_change",function(num, data){		//on item change, get item number and item data
		 //lets you want to load new items after 15 images loaded
    If((num%15) == 0) // every 15 items
    {
     // make an Ajax call here and append response to the div
    }
			});
    });
    public ActionResult List(string query,int page=0)
    {
    Int numberofitems = 30;
        var model = db.Photo.Select(m => new PhotoViewModel
        {
            Id = m.Id,
            Name = m.Name,
            StatusId = m.StatusId,
            SubmitDate = m.SubmitDate,
            FileAttachments = m.FileAttachments,
            SubmitNo = m.SubmitNo
        }).skip(page*numberofitems).take(numberofitems)
        .ToArray();
    
        return View("List", model);
    }
