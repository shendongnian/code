	SpeciesGridView.ascx
	
	<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Daff.Lae.TraceCommon.DTO.NoiReproNLS.SpeciesGridViewDTO>"%>
	<%@ Import Namespace="Daff.Lae.TraceCommon.ValueObjects" %>
	<%@ Import Namespace="Kendo.Mvc.UI" %>
	<%@ Import Namespace="Daff.Lae.TraceCommon.ValueObjects.NoiReproNLS" %>
	<%@ Import Namespace="System.Diagnostics" %>
	<%-- SpeciesGrid - render KendoGrid of NoiNlsConsignmentVO.  --%>
	<script runat="server">
		private IDictionary<string, object> readRouteValueDictionary = new Dictionary<string, object>();
		protected void Page_Load(object sender, EventArgs e)
		{
			readRouteValueDictionary.Add("applicationId", Model.NoiId);
			// SpeciesCode is optional.  If not given then all species are used.
			if (! Model.SpeciesCode.IsEmpty())
			{
				readRouteValueDictionary.Add("species", Model.SpeciesCode);
			}
		}
	</script>
	<fieldset>
		<legend><%=Model.SpeciesCode%></legend>
		<div>
	  
	   <% Html.Kendo().Grid<NoiNlsConsignmentVO>()
				  .Name("grdNlsConsignment"+Model.SpeciesCode)
                  ...
