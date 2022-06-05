using System;
using demo.Filters;
using demo.Models;

namespace demo.Services
{
	public interface IEngineService
    {
		public void SaveBlog(string title, string content);

	}

	public class EngineService : IEngineService
	{
		public int Count { get; set; } = 1;
		private readonly IServiceScopeFactory _serviceScopeFactory;
		public EngineService(IServiceScopeFactory serviceScopeFactory)
		{
			_serviceScopeFactory = serviceScopeFactory;
		}


		[Transactional]
		public void SaveBlog(string title, string content)
        {
            using var scope = _serviceScopeFactory.CreateScope();
			
            var ctx = scope.ServiceProvider.GetRequiredService<DemoContext>();
            ctx.Add(new Blog(title, content));
            ctx.SaveChangesAsync();
            Count++;

			int a = 1;
			while (a > 0)
			{

				a = a / (a - 1);
			}

		}
	}
}

