using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;
using RazorSignalRCoffee.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace RazorSignalRCoffee.Pages.CoffeePage
{
    public class DeleteModel : PageModel
    {
		private readonly ICoffeeRepository _coffeeRepository;
		private readonly IHubContext<MySignalHub> _hubContext;

		public DeleteModel(ICoffeeRepository coffeeRepository, IHubContext<MySignalHub> hubContext)
		{
			_coffeeRepository = coffeeRepository;
			_hubContext = hubContext;
		}

		[BindProperty]
        public Coffee Coffee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _coffeeRepository.GetById(id??0);

			if (coffee == null)
            {
                return NotFound();
            }
            else
            {
                Coffee = coffee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _coffeeRepository.Delete(id ?? 0);
            await _hubContext.Clients.All.SendAsync("LoadCoffee");

			return RedirectToPage("./Index");
        }
    }
}
