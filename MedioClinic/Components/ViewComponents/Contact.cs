#define no_suffix
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XperienceAdapter.Repositories;

namespace MedioClinic.Components.ViewComponents
{
	public class Contact : ViewComponent
	{
		private const string PagePath = "/Contact-us/Medio-Clinic";

		private readonly IPageRepository<Company, CMS.DocumentEngine.Types.MedioClinic.Company> _companyRepository;

		public Contact(IPageRepository<Company, CMS.DocumentEngine.Types.MedioClinic.Company> companyRepository)
		{
			_companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = (await _companyRepository.GetPagesInCurrentCultureAsync(
				CancellationToken.None,
				filter => filter
					.Path(PagePath)
					.TopN(1),
				buildCacheAction:
					cache => cache
						.Key($"{nameof(Contact)}|{nameof(InvokeAsync)}")
						.Dependencies((_, builder) => builder
							.PageType(CMS.DocumentEngine.Types.MedioClinic.Company.CLASS_NAME)
							.PagePath(PagePath, CMS.DocumentEngine.PathTypeEnum.Single))))
				.FirstOrDefault();

			return View(model);
		}
	}
}
