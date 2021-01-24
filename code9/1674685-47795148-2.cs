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
    
                accountIds().ForEach(i => multiReq.Requests.Add(getAccountRequest(i)));
    
                contactIds().ForEach(i => multiReq.Requests.Add(getContactRequest(i)));
    
                var multiResponse = (ExecuteMultipleResponse)svc.Execute(multiReq);
    
                foreach (var singleResponse in multiResponse.Responses)
                {
                    var retrieveResponse = (RetrieveMultipleResponse)singleResponse.Response;
    
                    var attributeName = "";
    
                    var logicalName = retrieveResponse.EntityCollection[0].LogicalName;
    
                    if ( logicalName == "account")
                    {
                        attributeName = "name";
                    }
                    else if (logicalName == "contact")
                    {
                        attributeName = "fullname";
                    }
    
                    var name = retrieveResponse.EntityCollection[0].GetAttributeValue<string>(attributeName);
    
                    Console.WriteLine(name);
                }
            }
    
            private RetrieveMultipleRequest getAccountRequest(Guid id)
            {
                return new RetrieveMultipleRequest
                {
                    Query = getAccountQuery(id)
                };
            }
    
            private QueryExpression getAccountQuery(Guid id)
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
                                Values = { id }
                            }
                        }
                    }
                };
            }
    
            private List<Guid> accountIds()
            {
                return new List<Guid>
                {
                    new Guid("{04C82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{06C82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{08C82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{0AC82C07-98F1-E611-9438-00155D6FD706}")
                };
            }
    
            private RetrieveMultipleRequest getContactRequest(Guid id)
            {
                return new RetrieveMultipleRequest
                {
                    Query = getContactQuery(id)
                };
            }
    
            private QueryExpression getContactQuery(Guid id)
            {
                return new QueryExpression
                {
                    EntityName = "contact",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        FilterOperator = LogicalOperator.And,
                        Conditions =
                        {
                            new ConditionExpression
                            {
                                AttributeName = "contactid",
                                Operator = ConditionOperator.Equal,
                                Values = { id }
                            }
                        }
                    }
                };
            }
    
            private List<Guid> contactIds()
            {
                return new List<Guid>
                {
                    new Guid("{6AC82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{6CC82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{6EC82C07-98F1-E611-9438-00155D6FD706}"),
                    new Guid("{70C82C07-98F1-E611-9438-00155D6FD706}")
                };
            }
        }
    }
