using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Repository;

namespace RazorSignalRCoffee.Pages.CoffeePage
{
    public class DetailsModel : PageModel
    {
		private readonly ICoffeeRepository _coffeeRepository;

		public DetailsModel(ICoffeeRepository coffeeRepository)
		{
			_coffeeRepository = coffeeRepository;
		}

		public Coffee Coffee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _coffeeRepository.GetById(id ?? 0);
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
    }
}
