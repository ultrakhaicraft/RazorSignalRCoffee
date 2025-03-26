using Microsoft.AspNetCore.SignalR;

namespace RazorSignalRCoffee.SignalR
{
	public class MySignalHub : Hub
	{

		public async Task SendMessage(string message)
		{
			await Clients.All.SendAsync("LoadCoffee", message);
		}

	}
}
