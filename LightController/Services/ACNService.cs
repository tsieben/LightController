using LightController.sACN;
using LightController.Data;

namespace LightController.Services
{
    public class ACNService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                SACNSender sender = new SACNSender(Guid.NewGuid(), "Light-Controller");

                while (!cancellationToken.IsCancellationRequested)
                {
                    sender.Send(1, LightStatus.data.ToArray()).Wait();
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
