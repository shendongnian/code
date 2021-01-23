    public void mapDrive(String driveChar, String server, String user, String password){
        String path = "use "+driveChar+": "+server +" /user:"+user+ " "+password;
        proc.StartInfo.FileName = "net";
        proc.StartInfo.Arguments = path;
        proc.StartInfo.UseShellExecute = false;
        proc.Start(); 
        proc.WaitForExit(10000); // wait 10 seconds at a maximum
    
       if(checkMappedDrive(driveChar)){
          //nice
       }else{
          //error
       }
    
    }
