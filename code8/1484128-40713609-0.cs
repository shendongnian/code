     public partial class MasterModel
        {
           
    //For single 
             public virtual Player Player{ get; set; }
            
             public virtual PartidoClub PartidoClub{ get; set; }
    //For List    
             public List<PartidoClub> liPartidoClub { get; set; }
             public List<Player > liPlayer { get; set; }
             
        }
        
    //Your Code On View 
        
    @model Application.Model.MasterModel
    //For First Grid On Same View 
    @(Html.Kendo().Grid(Model.liPartidoClub)
    .Name("grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.ClubDesc).Title("EQUIPO").Width(220);
            columns.Bound(c => c.PrtidoCodigo).Title("PJ").Width(60);
            columns.Bound(c => c.GolesClub).Title("GC").Width(60);
            columns.Bound(c => c.PuntosClub).Title("PUNTOS").Width(150);
        })
        .HtmlAttributes(new { style = "height: 300px;" })
        .Scrollable()
        .Reorderable(reorder => reorder.Columns(true))
        .Pageable(pageable => pageable
            .PageSizes(true))
        .DataSource(dataSource => dataSource
            .Ajax()
            .PageSize(20)
        )
    )
    //For Second Grid On Same View
    @(Html.Kendo().Grid<Model.liPlayer>()
        .Name("gridGoleadores")
        .Columns(columns =>
        {
            columns.Bound(c => c.NombreJugador).Title("JUGADOR").Width(220);
            columns.Bound(c => c.ClubDesc).Title("EQUIPO").Width(60);
            columns.Bound(c => c.GolesJugador).Title("GOLES").Width(60);
        })
        .HtmlAttributes(new { style = "height: 300px;" })
        .Scrollable()
        .Reorderable(reorder => reorder.Columns(true))
        .Pageable(pageable => pageable
        .PageSizes(true))
        .DataSource(dataSource => dataSource
            .Ajax()        
            .Read(read => read.Action("GoleadoresCampeonato", "Campeonato"))
            .PageSize(20)
            )
        )
