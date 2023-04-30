using LightController.sACN;
using LightController.Data;

namespace LightController.Services
{
    public class ACNService : IHostedService
    {
        
        /// <summary>
        /// Starts the backend service to continuously set the state of the lights
        /// </summary>
        /// <param name="cancellationToken">If this service should cancel</param>
        /// <returns>Task completed</returns>
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

        /// <summary>
        /// Called when background service is stopped
        /// </summary>
        /// <param name="cancellationToken">If the service should cancel</param>
        /// <returns>Task completed</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
