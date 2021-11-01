using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XperienceAdapter.Models;

namespace Business.Models
{
	/// <summary>
	/// Social media link.
	/// </summary>
	public class SocialLink : BasePage
	{
		public override IEnumerable<string> SourceColumns => base.SourceColumns.Concat(new[]
		{
		"Url",
		"Icon"
	});

		/// <summary>
		/// URL to social media.
		/// </summary>
		public string? Url { get; set; }

		/// <summary>
		/// URL of the service icon file.
		/// </summary>
		public IPageAttachmentUrl? IconUrl { get; set; }
	}

}
