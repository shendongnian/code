    using UnityEngine;
    using UnityEditor;
    using System.IO;
    /*   Project Name : Ember Guard
     *    Script Name : RemoveDeleteFile
     *    Script Path : Assets/Editor/RemoveDeleteFile.cs
     *  Script Author : FaalFaazDov || Raisltin M. Thoreson
     *     Created On : 29/08/2016 14:24
     *    Modified On : N/A
     *        Version : 0.0.1Alpha
     */
     /*************************************************************************
     *
     * Biophase Entertainment
     * __________________
     *
     *  [2016] Biophase Entertainment
     *  All Rights Reserved.
     *
     * NOTICE:  All information contained herein is, and remains
     * the property of Biophase Entertainment and its suppliers,
     * if any.  The intellectual and technical concepts contained
     * herein are proprietary to Biophase Entertainment
     * and its suppliers and may be covered by Canadian and Foreign Patents,
     * patents in process, and are protected by trade secret or copyright law.
     * Dissemination of this information, reproduction of this material or attempting
     * to read the content of these files is strictly forbidden unless prior written
     * permission is obtained from Biophase Entertainment.
     *
     */
    [InitializeOnLoad]
    public class Startup {
	    static Startup()
    	{
	    	int x = 0;
    		string path = Application.dataPath;
		    string[] files = Directory.GetFiles (path, "Delete This File.txt", SearchOption.AllDirectories);
	    	foreach (string f in files) {
    			File.Delete (f);
			    File.Delete (f + ".meta");
		    	x++;
	    	}
    		string fm;
		    if (x == 1) {
	    		fm = "file";
    		} else {
	    		fm = "files";
    		}
		    Debug.Log ("Deleted " + x + " " + fm + ".");
	    }
    }
