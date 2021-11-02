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
	public class SocialLinks : ViewComponent
	{
		private const string PagePath = "/Reused-content/Social-links";

		private readonly IPageRepository<SocialLink, CMS.DocumentEngine.Types.MedioClinic.SocialLink> _socialLinkRepository;

		public SocialLinks(IPageRepository<SocialLink, CMS.DocumentEngine.Types.MedioClinic.SocialLink> socialLinkRepository)
		{
			_socialLinkRepository = socialLinkRepository ?? throw new ArgumentNullException(nameof(socialLinkRepository));
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _socialLinkRepository.GetPagesInCurrentCultureAsync(
				CancellationToken.None,
				filter => filter
					.Path(PagePath, CMS.DocumentEngine.PathTypeEnum.Children),
				buildCacheAction: cache => cache
					.Key($"{nameof(SocialLinks)}|{nameof(InvokeAsync)}")
					.Dependencies((_, builder) => builder
						.PageType(CMS.DocumentEngine.Types.MedioClinic.SocialLink.CLASS_NAME)
						.PagePath(PagePath, CMS.DocumentEngine.PathTypeEnum.Children)
						.PageOrder()));

			return View(model);
		}
	}
}
