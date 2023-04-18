using Microsoft.EntityFrameworkCore;
using testOracleApp1.Data;
using testOracleApp1.Models;
using testOracleApp1.Repository.IRepository;

namespace testOracleApp1.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext appDbContext;

		public CategoryRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task<Category> AddAsync(Category category)
		{

			await appDbContext.Categories.AddAsync(category);
			await appDbContext.SaveChangesAsync();

			return category;
		}

		public async Task<Category?> DeleteAsync(int id)
		{
			var existingCategory = await appDbContext.Categories.FindAsync(id);

			if (existingCategory != null)
			{
				appDbContext.Categories.Remove(existingCategory);
				await appDbContext.SaveChangesAsync();
				return existingCategory;
			}

			return null;
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await appDbContext.Categories.ToListAsync();
		}

		public Task<Category?> GetAsync(int id)
		{
			return appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Category?> UpdateAsync(Category category)
		{
			var existingCategory = await appDbContext.Categories.FindAsync(category.Id);

			if (existingCategory != null)
			{
				existingCategory.Name = category.Name;

				//save
				await appDbContext.SaveChangesAsync();
				return existingCategory;
			}

			return null;
		}
	}
}
