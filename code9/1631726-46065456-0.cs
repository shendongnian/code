    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    using System.Runtime.InteropServices;
    public class Form1
    {
    	[DllImport("user32.dll")]
    	public static extern IntPtr SetCursor(IntPtr hCursor);
    
    	[DllImport("user32.dll")]
    	private static extern IntPtr LoadCursorFromFile(string lpFileName);
    
    	[DllImport("user32.dll")]
    	private static extern bool SetSystemCursor(IntPtr hCursor, int id);
    
    	private const uint OCR_NORMAL = 32512;
    
    	static Cursor ColoredCursor;
    
    	public Form1()
    	{
    		this.Load += Form1_Load;
    	}
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		this.CenterToScreen();
    	}
    
    	private void Button1_Click(object sender, EventArgs e)
    	{
    		IntPtr cursor = LoadCursorFromFile("C:\\Whatever\\Whatever\\example.cur");
    		bool ret_val = SetSystemCursor(cursor, OCR_NORMAL);
    	}
    }
