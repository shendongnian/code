    VimClient c = new VMware.Vim.VimClientImpl();
    ServiceContent sc = c.Connect("");
    UserSession us = c.Login("", "");
    NameValueCollection filter = new NameValueCollection();
    filter.Add("Id", "vm-12294");
     IList<VMware.Vim.EntityViewBase> vms2 = 
    c.FindEntityViews(typeof(VMware.Vim.VirtualMachine), null, filter, null);
