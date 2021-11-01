using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedioClinic.Models
{
	public class PageViewModel
	{
		public IPageMetadata Metadata { get; set; } = new MedioClinic.Models.PageMetadata();

		public UserMessage UserMessage { get; set; } = new UserMessage();

		public static PageViewModel GetPageViewModel(
			IPageMetadata pageMetadata,
			string? message = default,
			bool displayMessage = true,
			bool displayAsRaw = default,
			MessageType messageType = MessageType.Info) =>
			new PageViewModel()
			{
				Metadata = pageMetadata,
				UserMessage = new UserMessage
				{
					Message = message,
					MessageType = messageType,
					DisplayAsRaw = displayAsRaw,
					Display = displayMessage
				}
			};
	}
}
