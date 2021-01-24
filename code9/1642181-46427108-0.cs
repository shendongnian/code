    using System;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using Microsoft.Xrm.Tooling.Connector;
    using System.Collections.Generic;
    using System.Linq;
        private List<AttributeMetadata> getPicklists(IOrganizationService svc, string entity)
        {
            return allAttributes(svc, entity).Where(a => a.AttributeType == AttributeTypeCode.Picklist).ToList();
        }
        //Retrieve all attributes of an entity
        private List<AttributeMetadata> allAttributes(IOrganizationService svc, string entity)
        {
            var req = new RetrieveEntityRequest();
            req.EntityFilters = EntityFilters.Attributes;
            req.LogicalName = entity.ToLower();
            var response = (RetrieveEntityResponse)svc.Execute(req);
            return response.EntityMetadata.Attributes.ToList();
        }
