using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Repository;
using RazorSignalRCoffee.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace RazorSignalRCoffee.Pages.CoffeePage
{
    public class CreateModel : PageModel
    {
		private readonly ICoffeeRepository _coffeeRepository;
		private readonly IHubContext<MySignalHub> _hubContext;

		public CreateModel(ICoffeeRepository coffeeRepository, IHubContext<MySignalHub> hubContext)
		{
			_coffeeRepository = coffeeRepository;
			_hubContext = hubContext;
		}

		public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coffee Coffee { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _coffeeRepository.Add(Coffee);
			await _hubContext.Clients.All.SendAsync("LoadCoffee");

			return RedirectToPage("./Index");
        }
    }
}
