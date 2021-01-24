     var footer = Umbraco.TypedContent(NodeHelper.Settings.Footer).AsStronglyTyped<DocumentTypes.Repository.Footer>();
    
     if (footer.PoweredByImageId.HasValue)
                    {
                        this.imgPoweredBy.ImageUrl = MediaHelper.GetMediaUrlById(footer.PoweredByImageId.Value);
                        if (footer.PoweredByLink != null)
                        {
                            this.hplPoweredBy.NavigateUrl = footer.PoweredByLink.Url;
                        }
                    }
