    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    using UnityEngine.UI;
    public class UtilsMath : MonoBehaviour
    {
    private string gpsFilePath;
        private void Start()
    {
        gpsFilePath = Application.persistentDataPath + "/logFilesGPSUnity.txt";
        
        //if you want to empty the file every time the app starts,
        // only delete and create a new one.
        // if gps file exists
        if (File.Exists(gpsFilePath))
        {
            //delete file
            try
            {
                File.Delete(gpsFilePath);
                Debug.Log("[Utils Script]: GPS File Log Deleted Successfully!");
            }
            catch (System.Exception e)
            {
                Debug.LogError("[Utils Script]: Cannot delete GPS File Log - Exception: " + e);
            }
        }
    }
    
    /// <summary>
    /// <para> Writes the string message into the logFilesGPSUnity.txt in the internal storage\android\data\com.armis.arimarn\files\</para>
    /// You need to write a '\n' in the end or beginning of each message, otherwise, the message will be printed in a row.
    /// </summary>
    /// <param name="message">String to print in the file</param>
    public void WriteToFile(string message)
    {
        try
        {
            //create the stream writer to the specific file
            StreamWriter fileWriter = new StreamWriter(gpsFilePath, true);
            
            //write the string into the file
            fileWriter.Write(message);
            // close the Stream Writer
            fileWriter.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("[Utils Script]: Cannot write in the GPS File Log - Exception: " + e);
        }
    }
    
