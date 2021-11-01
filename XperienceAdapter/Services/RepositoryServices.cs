using CMS.Base;
using CMS.Helpers;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using XperienceAdapter.Repositories;

namespace XperienceAdapter.Services
{
	public class RepositoryServices : IRepositoryServices
	{
		public ISiteService SiteService { get; }

		public ISiteContextService SiteContextService { get; }

		public IPageRetriever PageRetriever { get; }

		public IPageUrlRetriever PageUrlRetriever { get; }

		public IPageAttachmentUrlRetriever PageAttachmentUrlRetriever { get; }

		public ISiteCultureRepository SiteCultureRepository { get; }

		public IProgressiveCache ProgressiveCache { get; }

        ISiteService IRepositoryServices.SiteService => throw new NotImplementedException();

        IPageRetriever IRepositoryServices.PageRetriever => throw new NotImplementedException();

        IPageUrlRetriever IRepositoryServices.PageUrlRetriever => throw new NotImplementedException();

        IPageAttachmentUrlRetriever IRepositoryServices.PageAttachmentUrlRetriever => throw new NotImplementedException();

        IProgressiveCache IRepositoryServices.ProgressiveCache => throw new NotImplementedException();


        public RepositoryServices(
			ISiteService siteService,
			ISiteContextService siteContextService,
			IPageRetriever pageRetriever,
			IPageUrlRetriever pageUrlRetriever,
			IPageAttachmentUrlRetriever pageAttachmentUrlRetriever,
			ISiteCultureRepository siteCultureRepository,
			IProgressiveCache progressiveCache)
		{
			SiteService = siteService ?? throw new ArgumentNullException(nameof(siteService));
			SiteContextService = siteContextService ?? throw new ArgumentNullException(nameof(siteContextService));
			PageRetriever = pageRetriever ?? throw new ArgumentNullException(nameof(pageRetriever));
			PageUrlRetriever = pageUrlRetriever ?? throw new ArgumentNullException(nameof(pageUrlRetriever));
			PageAttachmentUrlRetriever = pageAttachmentUrlRetriever ?? throw new ArgumentNullException(nameof(pageAttachmentUrlRetriever));
			SiteCultureRepository = siteCultureRepository ?? throw new ArgumentNullException(nameof(siteCultureRepository));
			ProgressiveCache = progressiveCache ?? throw new ArgumentNullException(nameof(progressiveCache));
		}
	}
}
