    var associateRequest = new AssociateRequest
                                       {
                                           Target =
                                               new EntityReference(
                                                   SalesOrder.EntityLogicalName,
                                                   salesOrderGuid),
                                           RelatedEntities =
                                               new EntityReferenceCollection
                                                   {
                                                       new EntityReference(
                                                           Annotation
                                                               .EntityLogicalName,
                                                           noteGuid)
                                                   },
                                           Relationship = GetRelationship<SalesOrder>(nameof(SalesOrder.SalesOrder_Annotation)) ///////////????
                                       };
