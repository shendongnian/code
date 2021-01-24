        public System.Collections.Generic.List<Renderer> renderers ;
		
		private void Start()
		{
			var sortedRenderers = new System.Collections.Generic.List<Renderer>( renderers ) ;
			sortedRenderers.Sort( SortLeftToRight ) ;
   
			for( int i = 0 ; i < sortedRenderers.Count ; ++i )
				Debug.Log( sortedRenderers[i].name ) ;
			
		}
		private int SortLeftToRight( Renderer r1, Renderer r2 )
		{
			Transform camTransform = Camera.main.GetComponent<Transform>(); // You can optimize if you cache the transform of the camera
			Vector3 axis = camTransform.right ; 
			Transform t1 = r1.gameObject.GetComponent<Transform>();
			Transform t2 = r2.gameObject.GetComponent<Transform>();
			float dot1 = Vector3.Dot( axis, t1.position - camTransform.position );
			float dot2 = Vector3.Dot( axis, t2.position - camTransform.position );
		
			if( Mathf.Abs( dot1 - dot2 ) < 0.001f )
				return 0 ;
		
			return dot1 < dot2 ? -1 : 1 ;
		}
