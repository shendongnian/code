    for( int i = 0; i < AList.Count; i++ )
    {
        string prop = AList[i];
        LinkLabel llbl = new LinkLabel()
        {
            AutoSize = true,
            Margin = new Padding( 0 ),
            Name = "llbl" + i,
            Text = prop + ", "
        };
        llbl.Links.Add( 0, prop.Length, string.Format( "{0}{1}", prefix, Sanitize( prop ) ) );
        flowLayoutPanel1.Controls.Add( llbl );
    }
