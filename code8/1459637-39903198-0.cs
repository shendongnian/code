      protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query)
        {
          bool? retry = new bool?();
          do
          {
            bool forceClose = false;
            try
            {
              using (new OrganizationServiceContextInitializer(this))
                return this.ServiceChannel.Channel.RetrieveMultiple(query);
            }
            catch (MessageSecurityException ex)
            {
              ..
            }
            finally
            {
              this.CloseChannel(forceClose);
            }
          }
          while (retry.HasValue && retry.Value);
          return (EntityCollection) null;
        }
