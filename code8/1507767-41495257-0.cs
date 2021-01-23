#***C++ Code:***
Header file "NativeLibrary.h":
    namespace NativeLibrary
    {
        extern "C" __declspec(dllexport) void __stdcall PassBitmap(int* number, int size);
    }
Cpp file "NativeLibrary.cpp":
    #include <NativeLibrary.h>
    void NativeLibrary::PassBitmap(int* number, int size) {
    	for (int i = 0; i < size; i++) {
    		number[i] = 123;
    	}
    }
#***C# Code:***
    using System.Drawing;
    using System.Runtime.InteropServices;
    
    [DllImport("NativeLibrary.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern void PassBitmap(IntPtr bmp, int size);
    
    public System.Drawing.Bitmap bitmap = null;
    
    
    public void GenerateAndModifyBitmap()
    {
    	//The pixel format is essential!
    	System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    	//Just which region we want to lock of the bitmap
    	System.Drawing.Rectangle rect = new System.Drawing.Rectangle(new System.Drawing.Point(), bmp.Size);
    	//We want to read and write to the data, pixel format stays the same (anything else wouldn't make much sense)
    	System.Drawing.Imaging.BitmapData data = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
    	//This is a pointer to the data in memory. Can be manipulated directly!
    	IntPtr ptr = data.Scan0;
    
    	// Declare an array to hold the bytes of the bitmap.
    	// This code is specific to a bitmap with 24 bits per pixels.
    	// Ignore current calculations. They are still work in progress xD
    	int size = bmp.Height;
    	size *= Math.Abs(data.Stride);
    	size /= 4;
    	//Call native function with our pointer to the data and of course how many ints we have
    	PassBitmap(ptr, size);
    	//Work is finished. Give our data back to the manager
    	bmp.UnlockBits(data);
    	bitmap = bmp;
    }
