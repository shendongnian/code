    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;
    using System;
    using System.Collections.Generic;
    
    namespace StackOverflow
    {
        public class App_ExecuteMultiple 
        {
            private IOrganizationService svc;
    
            public App_ExecuteMultiple(IOrganizationService svc) 
            {
                this.svc = svc;
            }
    
            public void Run()
            {
                var multiReq = new ExecuteMultipleRequest()
                {
                    Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    },
                    Requests = new OrganizationRequestCollection()
                };
    
                ids().ForEach(i => multiReq.Requests.Add(getRequest(i)));
    
                var multiResponse = (ExecuteMultipleResponse)svc.Execute(multiReq);
    
                foreach (var singleResponse in multiResponse.Responses)
                {
                    var retrieveResponse = (RetrieveMultipleResponse)singleResponse.Response;
    
                    Console.WriteLine(retrieveResponse.EntityCollection[0].GetAttributeValue<string>("name"));
                }
            }
    
            private RetrieveMultipleRequest getRequest(Guid id)
            {
                return new RetrieveMultipleRequest
                {
                    Query = getQuery(id)
                };
            }
    
            private QueryExpression getQuery(Guid id)
            {
                return new QueryExpression
                {
                    EntityName = "account",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        FilterOperator = LogicalOperator.And,
                        Conditions =
                        {
                            new ConditionExpression
                            {
                                AttributeName = "accountid",
                                Operator = ConditionOperator.Equal,
                                Values = { id}
                            }
                        }
                    }
                };
            }
    
            private List<Guid> ids()
            {
                return new List<Guid>
                {
                    new Guid("{04C82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{06C82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{08C82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{0AC82C07-98F1-E611-9438-00155D6FD706}"),
                };
            }
        }
    }
