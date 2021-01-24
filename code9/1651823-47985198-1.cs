    VimClientImpl client = new VimClientImpl();
    client.Login(vSphereURI, loginID, loginPW);
    List<EntityViewBase> vmlist = client.FindEntityViews(typeof(VirtualMachine), null, filter1, null);
    List<EntityViewBase> hostlist = client.FindEntityViews(typeof(HostSystem), null, null, null);
    
    foreach (HostSystem host in hostlist)
    {
       host.UpdateViewData();
       Console.WriteLine(@"# Host: " + host.Name + @": ");
                       
       for (int i = 0; i < host.Vm.Length; i++)
       {
          VirtualMachine vm = (VirtualMachine)client.GetView(host.Vm[i], null);
          Console.WriteLine(vm.Name);
       }
    }
    
    foreach (VirtualMachine vm in vmlist)
    {
       vm.UpdateViewData();
       HostSystem host = (HostSystem)client.GetView(vm.Runtime.Host, null);
       Console.WriteLine("name: " + vm.Name + " >>lives on>> " + host.Name);
    }
