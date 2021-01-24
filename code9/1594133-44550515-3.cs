    public static void Traverse( this GameObject gameobject, System.Action<GameObject> callback )
    {
        Transform transform = gameobject.transform;
        for ( int childIndex = 0 ; childIndex < transform.childCount ; ++childIndex )
        {
            GameObject child = transform.GetChild( childIndex ).gameObject;
            child.Traverse( callback );
            callback( child );
        }
    }
    // ...
    gameObject.Traverse( ( go ) =>
    {
        if(go.name == "HealthBar")
        {
            HealthBar = go ;
        }
    } ) ;
