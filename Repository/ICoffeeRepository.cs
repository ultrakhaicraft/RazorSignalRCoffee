using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public interface ICoffeeRepository
	{
		public Task<List<Coffee>> GetAll();
		public Task<Coffee> GetById(int id);
		public Task Add(Coffee coffee);
		public Task Delete(int id);
		public Task Update(Coffee coffee, int id);
	}
}
