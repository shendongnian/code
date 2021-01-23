    public class FilesCreateOptionalParms
            {
                /// Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders.
                public bool IgnoreDefaultVisibility { get; set; }  
                /// Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.
                public bool KeepRevisionForever { get; set; }  
                /// A language hint for OCR processing during image import (ISO 639-1 code).
                public string OcrLanguage { get; set; }  
                /// Whether to use the uploaded content as indexable text.
                public bool UseContentAsIndexableText { get; set; }  
            
            }
     
            /// <summary>
            /// Creates a new file. 
            /// Documentation https://developers.google.com/drive/v3/reference/files/create
            /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
            /// </summary>
            /// <param name="service">Authenticated drive service.</param>  
            /// <param name="body">A valid drive v3 body.</param>
            /// <param name="optional">Optional paramaters.</param>        /// <returns>FileResponse</returns>
            public static File Create(driveService service, File body, FilesCreateOptionalParms optional = null)
            {
                try
                {
                    // Initial validation.
                    if (service == null)
                        throw new ArgumentNullException("service");
                    if (body == null)
                        throw new ArgumentNullException("body");
    
                    // Building the initial request.
                    var request = service.Files.Create(body);
    
                    // Applying optional parameters to the request.                
                    request = (FilesResource.CreateRequest)SampleHelpers.ApplyOptionalParms(request, optional);
    
                    // Requesting data.
                    return request.Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("Request Files.Create failed.", ex);
                }
            }
