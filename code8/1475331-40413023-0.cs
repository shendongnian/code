	public class Course
	{
	    public int CourseID { get; set; }
	    public String Name { get; set; }
	    public Teacher Teacher { get; set; }
	    public String TeacherName 
	    { 
	    	get {
	    		return Teacher?.Name ?? Name
	    	}
	    }
	}
	<table class="table">
	    <tr>
	        <th>
	            @Html.DisplayNameFor(model => model.Name)
	        </th>
	        <th>
	            @Html.DisplayNameFor(model => model.TeacherName)
	        </th>
	    </tr>
	@foreach (var item in Model) {
	    <tr>
	        <td>
	            @Html.DisplayFor(modelItem => item.Name)
	        </td>
	        <td>
	            @Html.DisplayFor(modelItem => item.Teacher.Name)
	        </td>
	   </tr>
	}
