    public class ThumbnailsSetOptionalParms
            {
                /// Note: This parameter is intended exclusively for YouTube content partners. The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The actual CMS account that the user authenticates with must be linked to the specified YouTube content owner.
                public string OnBehalfOfContentOwner { get; set; }  
            
            }
     
            /// <summary>
            /// Uploads a custom video thumbnail to YouTube and sets it for a video. 
            /// Documentation https://developers.google.com/youtube/v3/reference/thumbnails/set
            /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
            /// </summary>
            /// <param name="service">Authenticated YouTube service.</param>  
            /// <param name="videoId">The videoId parameter specifies a YouTube video ID for which the custom video thumbnail is being provided.</param>
            /// <param name="optional">Optional paramaters.</param>        
            /// <returns>ThumbnailSetResponseResponse</returns>
            public static ThumbnailSetResponse Set(YouTubeService service, string videoId, ThumbnailsSetOptionalParms optional = null)
            {
                try
                {
                    // Initial validation.
                    if (service == null)
                        throw new ArgumentNullException("service");
                    if (videoId == null)
                        throw new ArgumentNullException(videoId);
    
                    // Building the initial request.
                    var request = service.Thumbnails.Set(videoId);
    
                    // Applying optional parameters to the request.                
                    request = (ThumbnailsResource.SetRequest)SampleHelpers.ApplyOptionalParms(request, optional);
    
                    // Requesting data.
                    return request.Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("Request Thumbnails.Set failed.", ex);
                }
            }
    
            
    	}
