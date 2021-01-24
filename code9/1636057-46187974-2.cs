    using System;
    using UnityEngine;
    
    public unsafe class DirtyHack
    {
        public Vector3[] vertices = new Vector3[65532];
        public int index;
    
        public void DirtyCopy(Mesh mesh)
        {
    		fixed (void* ptr = vertices)
    		{
    			*((UIntPtr*)ptr - 1) = (UIntPtr)(index * 4);
    			mesh.vertices = vertices;
    			*((UIntPtr*)ptr - 1) = (UIntPtr)(65532);
    		}
    	}
    }
