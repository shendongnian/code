    byte[] version = this.Request.GetVersionFromIfMatch();
    if (version != null)
    {
        if (!patch.TrySetPropertyValue(TableUtils.VersionPropertyName, version))
        {
            string error = TResources.TableController_CouldNotSetVersion.FormatForUser(TableUtils.VersionPropertyName, version);
            this.traceWriter.Error(error, this.Request, ServiceLogCategories.TableControllers);
            throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error));
        }
    }
