      private void StartWorkflow(SPListItem item, string wfName, SPUserToken userToken)
            {
                using (SPSite elevatedSite = new SPSite(item.Web.Site.ID, userToken))
                {
                    using (SPWeb elevatedWeb = elevatedSite.OpenWeb())
                    {
                        SPList parentList = elevatedWeb.Lists.TryGetList(item.ParentList.ToString());
                        SPWorkflowAssociationCollection associationCollection = parentList.WorkflowAssociations;
                        foreach (SPWorkflowAssociation association in associationCollection)
                        {
                            if (association.Name == wfName)
                            {
                                elevatedSite.WorkflowManager.StartWorkflow(item, association, association.AssociationData);
                                break;
                            }
                        }
                    }
                }
            }
