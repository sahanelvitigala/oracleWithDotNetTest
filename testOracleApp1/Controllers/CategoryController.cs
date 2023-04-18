using Microsoft.AspNetCore.Mvc;
using testOracleApp1.Models;
using testOracleApp1.Models.ViewModels;
using testOracleApp1.Repository.IRepository;

namespace testOracleApp1.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository categoryRepository;

		public CategoryController(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		// AdminCategory/
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Create")]
		public async Task<IActionResult> Create(CategoryCreateRequest categoryCreateRequest)
		{
			//Mapping CategoryCreateRequest to Category domain model
			var category = new Category
			{
				Name = categoryCreateRequest.Name
			};

			//inject
			await categoryRepository.AddAsync(category);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{

			//inject
			var categories = await categoryRepository.GetAllAsync();
			return View(categories);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var category = await categoryRepository.GetAsync(id);

			if (category != null)
			{
				var categoryEditRequest = new CategoryEditRequest
				{
					Id = category.Id,
					Name = category.Name

				};

				return View(categoryEditRequest);
			}

			return View(null);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var category = await categoryRepository.GetAsync(id);

			if (category != null)
			{
				var categoryEditRequest = new CategoryEditRequest
				{
					Id = category.Id,
					Name = category.Name

				};

				return View(categoryEditRequest);
			}

			return View(null);
		}



		[HttpPost]
		public async Task<IActionResult> Edit(CategoryEditRequest categoryEditRequest)
		{
			var category = new Category
			{
				Id = categoryEditRequest.Id,
				Name = categoryEditRequest.Name
			};

			var updatedCategory = await categoryRepository.UpdateAsync(category);

			if (updatedCategory != null)
			{
				//show success
				return RedirectToAction("Index");
			}
			else
			{
				//show error
			}
			return RedirectToAction("Edit", new { id = categoryEditRequest.Id });
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var category = await categoryRepository.GetAsync(id);

			if (category != null)
			{
				var categoryEditRequest = new CategoryEditRequest
				{
					Id = category.Id,
					Name = category.Name

				};

				return View(categoryEditRequest);
			}

			return View(null);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(CategoryEditRequest categoryEditRequest)
		{

			var deletedCategory = await categoryRepository.DeleteAsync(categoryEditRequest.Id);

			if (deletedCategory != null)
			{
				//show success
				return RedirectToAction("Index");
			}
			else
			{
				//show error
			}
			return RedirectToAction("Edit", new { id = categoryEditRequest.Id });

		}
	}
}
