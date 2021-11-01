using System;
using System.Collections.Generic;
using System.Text;
using XperienceAdapter.Repositories;
using XperienceAdapter.Services;

namespace Business.Repositories
{
	/// <summary>
	/// Stores company information.
	/// </summary>
	public class CompanyRepository : BasePageRepository<Models.Company, CMS.DocumentEngine.Types.MedioClinic.Company>
	{
		public override void MapDtoProperties(CMS.DocumentEngine.Types.MedioClinic.Company page, Models.Company dto)
		{
			dto.City = page.City;
			dto.Country = page.Country;
			dto.EmailAddress = page.EmailAddress;
			dto.PhoneNumber = page.PhoneNumber;
			dto.PostalCode = page.PostalCode;
			dto.Street = page.Street;
		}

		public CompanyRepository(IRepositoryServices repositoryDependencies) : base(repositoryDependencies)
		{
		}
	}
}
