    using System;
    using UnityEngine;
    
    public unsafe class DirtyHack
    {
    	public Vector3[] vertices = new Vector3[65532];
    	public int index;
    
    	public void* vertices1;
    
    	public DirtyHack()
    	{
    		fixed (void* ptr = vertices)
    		{
    			vertices1 = ptr;
    		}
    	}
    
    	public void DirtyCopy(Mesh mesh)
    	{
    		*((UIntPtr*)vertices1 - 1) = (UIntPtr)(index * 4);
    		mesh.vertices = vertices;
    		*((UIntPtr*)vertices1 - 1) = (UIntPtr)(65532);
    	}
    }
