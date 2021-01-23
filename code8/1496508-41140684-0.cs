    /// <summary>
    /// returns diagram image
    /// </summary>
    public Image image
    {
    	get 
    	{
    		EA.Project projectInterface = this.model.getWrappedModel().GetProjectInterface();
    		string diagramGUID = projectInterface.GUIDtoXML(this.wrappedDiagram.DiagramGUID);
    		string filename = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
    		//save diagram image to file (format ".png")
    		projectInterface.PutDiagramImageToFile(diagramGUID, filename, 1);
    		//load the contents of the file into a memorystream
    		MemoryStream imageStream = new MemoryStream(File.ReadAllBytes(filename));
    		//then create the image from the memorystream.
    		//this allows us to delete the temporary file right after loading it.
    		//When using Image.FromFile the file would have been locked for the lifetime of the Image
    		Image diagramImage = Image.FromStream(imageStream);
    		//delete the temorary file
    		System.IO.File.Delete(filename);
    
    		return diagramImage;
    	}
    }
