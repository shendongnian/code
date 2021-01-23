    try
                {
                    //Using the IComponentModel service
                    var componentModel = (IComponentModel)this.ServiceProvider.GetService(typeof(SComponentModel));
    
                    //var sourceProvider = componentModel.GetService<IVsPackageSourceProvider>();
    
                    IVsPackageInstallerServices installerServices =
                        componentModel.GetService<IVsPackageInstallerServices>();
    
    
                    var installedPackages = installerServices.GetInstalledPackages();
                   
    
    
                }
                catch (Exception ex)
                {
                }
