         <div id="flOther" runat="server">
        <div id="fileOtherUploadarea">
        <asp:FileUpload ID="flOtherUPL" runat="server" />
        </div>
         <input style="width: 20px; border: 0px none; background-color:transparent;" id="btnOtherAddMoreFiles" type="button"     onclick="AddOtherMoreImages();" class="icon-plus-sign" />|
       <asp:LinkButton ID="lnkOtherUpload" OnCommand="btnLnk_UploadOtherFiles" CommandArgument='<%# Eval("ID")   %>   'runat="server">Upload Files</asp:LinkButton>
        </div>
    
        <script language="javascript" type="text/javascript">
    
            function AddMoreImages() {
                if (!document.getElementById && !document.createElement)
                    return false;
                var fileUploadarea = document.getElementById("fileUploadarea");
                if (!fileUploadarea)
                    return false;
                var newLine = document.createElement("br");
                fileUploadarea.appendChild(newLine);
                var newFile = document.createElement("input");
                newFile.type = "file";
                newFile.setAttribute("class", "fileUpload");
    
                if (!AddMoreImages.lastAssignedId)
                    AddMoreImages.lastAssignedId = 100;
                newFile.setAttribute("id", "FileUpload" + AddMoreImages.lastAssignedId);
                newFile.setAttribute("name", "FileUpload" + AddMoreImages.lastAssignedId);
                var div = document.createElement("div");
                div.appendChild(newFile);
                div.setAttribute("id", "div" + AddMoreImages.lastAssignedId);
                fileUploadarea.appendChild(div);
                AddMoreImages.lastAssignedId++;       }   
       
        </script>
    
    
    
    protected void btnLnk_UploadOtherFiles(object sender, CommandEventArgs e)
        {
        int ID;
      
        try
        {
            if (!String.IsNullOrEmpty(Convert.ToString(e.CommandArgument)))
            {
                ID = Convert.ToInt32(e.CommandArgument);
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string fileExtension = System.IO.Path.GetExtension(hpf.FileName);
                        if (ValidExtesion(fileExtension))
                        {
                            int MaxSizeAllowed = Convert.ToInt32(ConfigurationManager.AppSettings["MaxFileSize"]);
                            if (hpf.ContentLength < MaxSizeAllowed)
                            {
                                int lastIndex = Convert.ToInt32(hpf.FileName.LastIndexOf("\\"));
                                string FileName = DateTime.Now.Millisecond + hpf.FileName.Substring(lastIndex + 1);
                                string FileName1 = hpf.FileName.Substring(lastIndex + 1);
                                FileName = FileName.Replace(" ", "");
                                StringBuilder AncTag = new StringBuilder();
                                AncTag = AncTag.Append("<a href='Attachments/AMT/'" + FileName + "' target='_blank'>'" + FileName1 + "' </a>");
                                string strAncTag = AncTag.ToString();
                                strAncTag = strAncTag.Replace("'", "");
                                hpf.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Attachments/AMT/" + FileName);
                                obj.UploadOtherFiles_ProblemDescription(ID, strAncTag);
                            }
                            else
                            {
                                
                            }
                        }
                        else
                        {
                            
                        }
                    }
                }
               
            }
        }
        catch (Exception ex)
        {
            ErrorLog objER = new ErrorLog(ex);
        }
        finally
        {
            obj = null;
            grdPDC.EditIndex = -1;
           
        }
    }
