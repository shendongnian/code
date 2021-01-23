    database.AssetAssigneeMappers.Add(new AssetAssigneeMapper()
                                        {
                                            assignedQty = quantity,
                                            employeeName = employeeName,
                                            assetId=Check.assetId
                                        });
                                        database.SaveChanges();
