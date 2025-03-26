using BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class CoffeeRepository : ICoffeeRepository
	{
		public async Task Add(Coffee coffee)
		{
			await CoffeeDAO.Instance.Add(coffee);
		}

		public async Task Delete(int id)
		{
			await CoffeeDAO.Instance.Delete(id);
		}

		public async Task<List<Coffee>> GetAll()
		{
			return await CoffeeDAO.Instance.GetAll();
		}

		public async Task<Coffee> GetById(int id)
		{
			return await CoffeeDAO.Instance.GetById(id);
		}

		public async Task Update(Coffee coffee, int id)
		{
			await CoffeeDAO.Instance.Update(coffee, id);	
		}
	}
}
