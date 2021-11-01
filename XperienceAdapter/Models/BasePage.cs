using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace XperienceAdapter.Models
{
	public class BasePage
	{
		public virtual IEnumerable<string> SourceColumns => new List<string>
	{
		"DocumentID",
		"DocumentGUID",
		"DocumentName",
		"DocumentCulture",
		"NodeID",
		"NodeGUID",
		"NodeAliasPath",
		"NodeParentID",
		"NodeSiteID",
		"NodeLevel",
		"NodeOrder"
	};

		public int NodeId { get; set; }

		public Guid Guid { get; set; }

		public string? Name { get; set; }

		public string? NodeAliasPath { get; set; }

		public int? ParentId { get; set; }

		public SiteCulture? Culture { get; set; }

		public IList<PageAttachment> Attachments { get; } = new List<PageAttachment>();
	}

	public class PageAttachment
	{
		public int Id { get; set; }

		public Guid Guid { get; set; }

		public string? Title { get; set; }

		public string? FileName { get; set; }

		public string? Extension { get; set; }

		public string? MimeType { get; set; }

		public IPageAttachmentUrl? AttachmentUrl { get; set; }
	}
}
