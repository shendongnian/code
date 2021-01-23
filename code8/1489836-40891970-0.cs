    var attachmentsList = new List<RootObject>();
    FileInfo[] files = dinfo.GetFiles();
    var rootObject = new RootObject {  
                                        id = 1, 
                                        name = "Folder1", 
                                        children = new List<Child>()
                                    };
    foreach (FileInfo file in files)
    {
          rootObject.children.Add(new Child { id = i + 1, file.Name });
          i++;
    }
    attachmentsList.Add(rootObject);
