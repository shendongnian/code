    // Drag & Drop the vertical layout group here
    public UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup ;
       
    // ... In your function
    RectTransform parent = verticalLayoutGroup.GetComponent<RectTransform>() ;
    for( int index = 0 ; index < stringList.Count ; ++index )
    {
         GameObject g = new GameObject( stringList[index] ) ;
         UnityEngine.UI.Text t = g.AddComponent<UnityEngine.UI.Text>();
         t.addComponent<RectTransform>().setParent( parent ) ;
         t.text = stringList[index] ;
    }
