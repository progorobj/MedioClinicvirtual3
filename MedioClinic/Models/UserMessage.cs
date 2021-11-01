using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedioClinic.Models
{
	public class UserMessage
	{
		public MessageType MessageType { get; set; }

		public string? Message { get; set; }

		public bool DisplayAsRaw { get; set; }

		public bool Display { get; set; }
	}

	public enum MessageType
	{
		Info,
		Warning,
		Error
	}

	public class PageViewModel<TViewModel> : PageViewModel
	{
		public TViewModel Data { get; set; } = default!;

		public static PageViewModel<TViewModel> GetPageViewModel(
			TViewModel data,
			IPageMetadata pageMetadata,
			string? message = default,
			bool displayMessage = true,
			bool displayAsRaw = default,
			MessageType messageType = MessageType.Info) =>
			new PageViewModel<TViewModel>()
			{
				Metadata = pageMetadata,
				UserMessage = new UserMessage
				{
					Message = message,
					MessageType = messageType,
					DisplayAsRaw = displayAsRaw,
					Display = displayMessage
				},
				Data = data
			};
	}
}
