    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    
    using WebApplication.Services;
    
    namespace WebApplication.Controllers
    {
    [Route("render")]
    public class RenderController : Controller
    {
    	private readonly IViewRenderService _viewRenderService;
     
    	public RenderController(IViewRenderService viewRenderService)
    	{
    		_viewRenderService = viewRenderService;
    	}
     
    	[Route("invite")]
    	public async Task<IActionResult> RenderInviteView()
    	{
            ViewData["Message"] = "Your application description page.";
    		var viewModel = new InviteViewModel
    		{
    			UserId = "cdb86aea-e3d6-4fdd-9b7f-55e12b710f78",
    			UserName = "Hasan",
    			ReferralCode = "55e12b710f78",
    			Credits = 10
    		};
     
    		var result = await _viewRenderService.RenderToStringAsync("Email/Invite", viewModel);
    		return Content(result);
    	}
    }
    
    public class InviteViewModel {
        	public string	UserId {get; set;}
    		public string	UserName {get; set;}
    		public string	ReferralCode {get; set;}
    		public int	Credits {get; set;}
    } 
    }
    
      
