    ManagementObject GetBitLockerManager( string driveLetter )
    {
        var path = new ManagementPath( );
        path.Server = string.Empty;
        path.NamespacePath = @"\ROOT\CIMV2\Security\MicrosoftVolumeEncryption";
        path.ClassName = "Win32_EncryptableVolume";
        var options = new ConnectionOptions( );
        options.Impersonation = ImpersonationLevel.Impersonate;
        options.EnablePrivileges = true;
        options.Authentication = AuthenticationLevel.PacketPrivacy;
        var scope = new ManagementScope( path, options );
        var mgmt = new ManagementClass( scope, path, new ObjectGetOptions( ) );
        mgmt.Get( );
        return mgmt
          .GetInstances( )
          .Cast<ManagementObject>( )
          .FirstOrDefault
          ( vol => 
            string.Compare
            (
              vol[ "DriveLetter" ] as string, 
              driveLetter, 
              true
            ) == 0 
          );
    }
