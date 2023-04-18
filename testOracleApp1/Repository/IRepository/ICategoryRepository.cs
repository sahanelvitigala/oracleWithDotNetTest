using testOracleApp1.Models;

namespace testOracleApp1.Repository.IRepository
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllAsync();

		Task<Category?> GetAsync(int id);

		Task<Category> AddAsync(Category category);

		Task<Category?> UpdateAsync(Category category);

		Task<Category?> DeleteAsync(int id);
	}
}
