using CMS.DocumentEngine;
using System;
using System.Collections.Generic;
using System.Text;
using XperienceAdapter.Models;
using XperienceAdapter.Repositories;
using XperienceAdapter.Services;

namespace Business.Repositories
{
	/// <summary>
	/// Stores pages without page type-specific data (coupled data).
	/// </summary>
	public class BasePageRepository : BasePageRepository<BasePage, TreeNode>
	{
		public BasePageRepository(IRepositoryServices repositoryDependencies) : base(repositoryDependencies)
		{
		}
	}
}
