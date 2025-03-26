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
    public class IndexModel : PageModel
    {
        
        private readonly ICoffeeRepository _coffeeRepository;

		public IndexModel(ICoffeeRepository coffeeRepository)
		{
			_coffeeRepository = coffeeRepository;
		}

		public IList<Coffee> Coffee { get;set; } = default!;

		/*
        public async Task OnGetAsync()
        {
            Coffee = await _coffeeRepository.GetAll();
		}
		*/

		public async Task<JsonResult> OnGetCoffeeListAsync()
		{
			var coffeeList = await _coffeeRepository.GetAll();
			return new JsonResult(coffeeList);
		}
	}
}
