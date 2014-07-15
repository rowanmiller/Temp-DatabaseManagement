using Microsoft.AspNet.SignalR;

namespace FakeEstateWeb.Hubs
{
    public class MigrationActivityHub : Hub
    {
        public static void Info(string context, string message)
        {
            GlobalHost.ConnectionManager.GetHubContext<MigrationActivityHub>().Clients.All.info(context, message);
        }

        public static void Warning(string context, string message)
        {
            GlobalHost.ConnectionManager.GetHubContext<MigrationActivityHub>().Clients.All.warning(context, message);
        }

        public static void Verbose(string context, string message)
        {
            GlobalHost.ConnectionManager.GetHubContext<MigrationActivityHub>().Clients.All.verbose(context, message);
        }
    }
}