      var a = contex.InsurancePolicyItem.Where(w => w.IsActive && w.IsVisible && w.ItemCreatedStatusId != Helpers.InsurancePolicyItemStatus.Draft)
                                                           .Select(s => new InsurancePolicyItemViewModel(s)
                                                           {
                                                               CustomerList = s.InsurancePolicyItemCustomers.Join(contex.Customers,
                                                                                     q => q.CustomersId,
                                                                                     c => c.CustomersId,
                                                                                     (q, c) => new
                                                                                     {
                                                                                         customerList = c
                                                                                     }).Select(ss => ss.customerList),
                                                               InstallmentList = s.InsurancePolicyItemInstallment,
                                                               FileList = s.InsurancePolicyItemFile,
                                                           });
