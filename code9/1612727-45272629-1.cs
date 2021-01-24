    @{
        string folderPath = Server.MapPath("/media");
        string[] files = Directory.GetFiles(folderPath + "/" + Model.Content.GetPropertyValue("Name"));
    }
	@for(int i =0; i < files.Length; i++)
	{
		var item = files[i];
		<li data-src="/media/@Model.Content.GetPropertyValue("Name")/@Path.GetFileName(item)" data-sub-html="">
						<a href="">
							// when greater than 1 means when value is 2 or above (3rd collection in the array)
							if(i >1)
							{
								<img src="/media/@Model.Content.GetPropertyValue("Name")/@Path.GetFileName(item)"/>
							}
						</a>
					</li>
	}
