    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public static class DragForce {
    
    	const float EPSILON = 0.000001f;
    
    
    	public static float Calculate (float coefficient, float density, float vsq, float A) {
    		float f = coefficient * density * vsq * A;
    		return f;
    	}
    
    	public static float Calculate (float vsq, float A) {
    		return Calculate (1f, 1f, vsq, A);
    	}
    
    
    }
