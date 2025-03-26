using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
	public class CoffeeDAO
	{
		private static CoffeeDAO _instance;
		private CoffeeShopContext context;
		public static CoffeeDAO Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CoffeeDAO();
				}
				return _instance;
			}
		}

		public CoffeeDAO()
		{
			this.context = new CoffeeShopContext();
		}

		public async Task<List<Coffee>> GetAll()
		{
			return await context.Coffees
				.OrderByDescending(c => c.Id)
				.ToListAsync();
		}
		
		public async Task<Coffee> GetById(int id)
		{
			return await context.Coffees
				.AsNoTracking()
				.SingleOrDefaultAsync(m=>m.Id.Equals(id));
		}	

		public async Task Add(Coffee coffee)
		{
			context.Coffees.Add(coffee);
			await context.SaveChangesAsync();
		}

		public async Task Delete(int id) {
			Coffee coffee = await GetById(id);
			if(coffee != null)
			{
				context.Entry(coffee).State = EntityState.Detached;
				context.Coffees.Remove(coffee);
				await context.SaveChangesAsync();
			}
		}

		public async Task Update(Coffee coffee,int id) {
			Coffee currentCoffee = await GetById(id);
			if (currentCoffee != null)
			{
				context.Entry(currentCoffee).State = EntityState.Detached;
				context.Coffees.Attach(coffee);
				context.Coffees.Entry(coffee).State=EntityState.Modified;
				await context.SaveChangesAsync();
			}

		}
	}
}
