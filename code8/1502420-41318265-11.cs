    public ActionResult Edit([Bind(Include = "BusinessId,Name,About,Phone,TollFree,
                        FAX,Email,Bio")] Business business,HttpPostedFileBase BioPhoto)
    {
       // to do read BioPhoto.InputStream and convert to your byteArray
       // to do  :Return something
    }
