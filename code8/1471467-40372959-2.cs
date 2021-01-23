    using UnityEngine;
    
    public class RunR : MonoBehaviour
    {
    	void Start ()
    	{
    		System.Diagnostics.Process process = new System.Diagnostics.Process();
            // For macOS, here should be "/bin/sh", I think.
    		process.StartInfo.FileName = @"E:\Program Files\R\R-3.3.2\bin\x64\Rscript.exe";
            // For macOS, here should be "-c path_of_the_Rscript Rexp1.R", I think.
    		process.StartInfo.Arguments = "Rexp1.R";
    		process.StartInfo.WorkingDirectory = Application.dataPath;
    		process.StartInfo.UseShellExecute = false;
    		process.StartInfo.RedirectStandardOutput = true;
    		process.StartInfo.RedirectStandardError = true;
    		process.Start();
    		//read the output
    		string output = process.StandardOutput.ReadToEnd();
    		string err = process.StandardError.ReadToEnd();
    		process.WaitForExit();
    		Debug.Log(output);
    		Debug.LogError(err);
    	}
    }
