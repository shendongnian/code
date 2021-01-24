	Consignment.ascx
	
    <%
        var applicationId = ViewData["NoiId"];
        var allSpecies = ViewData["allSpecies"] as List<ListItem>;       
    %>
    ...
	<%
    foreach (ListItem speciesItem in allSpecies)
    {
        var species = speciesItem.Value.Replace(" ", "_");%>
        <div id="<%=species%>_grid" style="display: none;">
            <%
                Html.RenderPartial("~/Views/Noi/ReproNLS/SpeciesGridView.ascx", new SpeciesGridViewDTO( NoiId : (int) applicationId, SpeciesCode : species));
            %>
        </div>
    <%}%>
----
	SpeciesGridViewDTO.cs
	
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;
	namespace Daff.Lae.TraceCommon.DTO.NoiReproNLS
	{
		/// <summary>
		/// This DataTransferObject is for sending a succinct model to the SpeciesGridView
		/// </summary>
		[DataContract, Serializable]
		public class SpeciesGridViewDTO
		{
			[DataMember]
			public Int32 NoiId { get; set; }
			[DataMember]
			public String SpeciesCode { get; set; }
			public SpeciesGridViewDTO(int NoiId, string SpeciesCode)
			{
				this.NoiId = NoiId;
				this.SpeciesCode = SpeciesCode;
			}
		}
	}
