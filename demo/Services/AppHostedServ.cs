using System;

namespace demo.Services
{
	public class AppHostedServ : IHostedService
	{
        private readonly IServiceProvider _serviceProvider;

        public AppHostedServ() { }

		public AppHostedServ(IServiceProvider serviceProvider)
		{
            _serviceProvider = serviceProvider;
		}

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("================> Hello");
            //_serviceProvider.GetRequiredService<Enging>().SaveBlog();
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

