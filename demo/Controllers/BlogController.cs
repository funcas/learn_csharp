using System;
using demo.Filters;
using demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BlogController : ControllerBase
	{
		private readonly DemoContext _demoContext;
		private readonly IEngineService _engineService;

		public BlogController(DemoContext demoContext, IEngineService engineService)
        {
			_demoContext = demoContext;
			_engineService = engineService;
        }

		[HttpGet("save")]
		
        public string Save()
		{
			_engineService.SaveBlog("1","99999");

			
			return "success";
		}

		[HttpGet("read")]
		public object Read(int id)
        {
			return _demoContext.Blogs.Where(q => q.BlogId == id).Single();
        }

		[HttpGet("except")]
		public object except()
        {
			_engineService.SaveBlog("2", "3333");
			return "success";
        }
	}
}

