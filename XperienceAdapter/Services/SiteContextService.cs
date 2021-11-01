using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace XperienceAdapter.Services
{
	public class SiteContextService : ISiteContextService
	{
		public bool IsPreviewEnabled => HttpContextAccessor.HttpContext.Kentico().Preview().Enabled;

		private IHttpContextAccessor HttpContextAccessor { get; }

		public SiteContextService(IHttpContextAccessor httpContextAccessor)
		{
			HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
		}
	}
}
