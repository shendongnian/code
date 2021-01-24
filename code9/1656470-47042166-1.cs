                            Guid oppProdId = targetEntity.Id;
    
                            // retrieve oppid guid
                            Entity oppProd = new Entity("child_entity");
                            ColumnSet columns_ = new ColumnSet(new string[] { "lookup_fieldtoParent" });
                             oppProd = service.Retrieve(oppProd.LogicalName, oppProdId, columns_);
    
                            Guid oppId = new Guid();
                            oppId = ((EntityReference)oppProd["lookup_fieldtoParent"]).Id;
    
                            //throw new InvalidPluginExecutionException(
    
                            queryOppProdOnDel(service, oppId, oppProdId);
                        }
