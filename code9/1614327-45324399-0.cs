    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class ObjectFinder
    {
    	private static object CreateObjectInstance(string objectName)
    	{
    		// Creates and returns an instance of any object in the assembly by its type name.
    		object obj = null;
    		try {
    			if (objectName.LastIndexOf(".") == -1) {
    				//Appends the root namespace if not specified.
    				objectName = string.Format("{0}.{1}", Assembly.GetEntryAssembly.GetName.Name, objectName);
    			}
    			obj = Assembly.GetEntryAssembly.CreateInstance(objectName);
    		} catch (Exception ex) {
    			obj = null;
    		}
    		return obj;
    	}
    
    	public static Form CreateForm(Form objForm, string strName, string strAddr, string strCity)
    	{
    		// Return the instance of the form by specifying its name.
    		var objChild = (objForm)CreateObjectInstance(objForm.Name);
    		objChild.strName = txtName.Text1;
    		objChild.strAddr = txtAddress.Text2;
    		objChild.strCity = txtCity.Text2;
    		return objChild;
    	}
    }
