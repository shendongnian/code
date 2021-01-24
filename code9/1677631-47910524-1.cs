    var reportFilterDb =
                    _iGenericReportProcRepository.ExecuteStoredProcedureFunction("EXEC StoredProcedureReport @QuotationNo, @AgencyName, @ContractStartDate, @ContractEndDate, @contractTerm",
                        new SqlParameter("@QuotationNo", SqlDbType.VarChar) { Value = (object)filter.QuotationNo ?? DBNull.Value },
                        new SqlParameter("@AgencyName", SqlDbType.VarChar) { Value = (object)filter.AgencyName ?? DBNull.Value },
                        new SqlParameter("@ContractStartDate", SqlDbType.DateTime) { Value = (object)filter.FContractStartDate ?? DBNull.Value },
                        new SqlParameter("@ContractEndDate", SqlDbType.DateTime) { Value = (object)filter.FContractEndDate ?? DBNull.Value  },
                        new SqlParameter("@contractTerm", SqlDbType.Int) { Value = (object)filter.Term ?? DBNull.Value  }
                        ).ToList();
