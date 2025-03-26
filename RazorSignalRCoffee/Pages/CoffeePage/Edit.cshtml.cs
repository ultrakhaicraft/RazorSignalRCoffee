using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;
using RazorSignalRCoffee.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace RazorSignalRCoffee.Pages.CoffeePage
{
    public class EditModel : PageModel
    {
		private readonly ICoffeeRepository _coffeeRepository;
		private readonly IHubContext<MySignalHub> _hubContext;

		public EditModel(ICoffeeRepository coffeeRepository, IHubContext<MySignalHub> hubContext)
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

            var coffee =  await _coffeeRepository.GetById(id ?? 0);
			if (coffee == null)
            {
                return NotFound();
            }
            Coffee = coffee;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _coffeeRepository.Update(Coffee,Coffee.Id);
			await _hubContext.Clients.All.SendAsync("LoadCoffee");

			return RedirectToPage("./Index");
        }

        
    }
}
