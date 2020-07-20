using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication7
{
    internal class LoggingService : BackgroundService
    {
        private ILogger _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ = Task.Run(() =>
              {
                  while (!stoppingToken.IsCancellationRequested)
                  {
                      _logger.LogInformation("Log from Task 1");
                  }
              }, stoppingToken);
            _ = Task.Run(() =>
              {
                  while (!stoppingToken.IsCancellationRequested)
                  {
                      _logger.LogInformation("Log from Task 2");
                  }
              }, stoppingToken);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}