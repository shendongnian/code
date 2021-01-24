    using System;
    using System.Collections;
    using PX.Data;
    using PX.Objects.AR;
    namespace PXExtendCustomerToVendorExtPkg
    {
        public class CustomerMaintPXExt : PXGraphExtension<CustomerMaint>
        {
            public PXAction<Customer> extendToVendorPXExt;
            [PXUIField(DisplayName = "Extend To Vendor Ext",
                       MapEnableRights = PXCacheRights.Select, 
                       MapViewRights = PXCacheRights.Select, 
                       Visible = false)]
            [PXButton]
            public virtual IEnumerable ExtendToVendorPXExt(PXAdapter adapter)
            {
                try
                {
                    if (Base.extendToVendor.GetEnabled())
                        Base.extendToVendor.Press();
                }
                catch (Exception ex)
                {
                    if (ex is PXRedirectRequiredException)
                    {
                        PXRedirectRequiredException rdEx = (PXRedirectRequiredException)ex;
                        rdEx.Graph.Actions.PressSave();
                    }
                    else
                        throw ex;
                }
                return adapter.Get();
            }
        }
    }
