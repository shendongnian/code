    using UnityEngine;
    
    public class RunR : MonoBehaviour
    {
    	void Start ()
    	{
    		System.Diagnostics.Process process = new System.Diagnostics.Process();
    		process.StartInfo.FileName = @"E:\Program Files\R\R-3.3.2\bin\x64\Rscript.exe";
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
