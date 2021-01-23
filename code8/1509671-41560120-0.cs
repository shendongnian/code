    public void createUsWithAttachmentList(string workspace, string project, string userStoryName, string userStoryDescription)
    {
        //authentication
        this.EnsureRallyIsAuthenticated();
        //Userstory setup
        DynamicJsonObject toCreate = new DynamicJsonObject();
        toCreate["Workspace"] = workspace;
        toCreate["Project"] = project;
        toCreate["Name"] = userStoryName;
        toCreate["Description"] = userStoryDescription;
        //Create the story first
        try
        {
            //create user story
            CreateResult createUserStory = _api.Create(RallyField.userStory, toCreate);
            //now loop over each file 
            string[] attachmentPath = Directory.GetFiles("C:\\Users\\user\\Desktop\\RallyAttachments");
 
            foreach (string fileName in attachmentPath)
            {
                //DynamicJSONObject for AttachmentContent
                DynamicJsonObject myAttachmentContent = new DynamicJsonObject();
                Image myImage = Image.FromFile(fileName);
                string imageBase64String = imageToBase64(myImage, System.Drawing.Imaging.ImageFormat.Png);
                int imageNumberBytes = Convert.FromBase64String(imageBase64String).Length;
                myAttachmentContent[RallyField.content] = imageBase64String;
                //create the AttachmentConent
                CreateResult myAttachmentContentCreateResult = _api.Create(RallyField.attachmentContent, myAttachmentContent);
                String myAttachmentContentRef = myAttachmentContentCreateResult.Reference;
                //create an Attachment to associate to story
                DynamicJsonObject myAttachment = new DynamicJsonObject();
                myAttachment["Artifact"] = createUserStory.Reference;
                myAttachment["Content"] = myAttachmentContentRef;
                myAttachment["Name"] = "AttachmentFromREST.png";
                myAttachment["Description"] = "Email Attachment";
                myAttachment["ContentType"] = "image/png"; 
                myAttachment["Size"] = imageNumberBytes;
                //create & associate the attachment
                CreateResult myAttachmentCreateResult = _api.Create(RallyField.attachment, myAttachment);
            }     
        }
        catch (WebException e)
        {
            Console.WriteLine(e.Message);
        }
    }
