﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedioClinic.Models.ViewComponents.Navigation
{
	public class TopNavigationContentsModel
	{
		public string? MainId { get; set; }

		public string? CultureSwitchId { get; set; }

		public string? ListClass { get; set; }

		public NavigationItem? Navigation { get; set; }

		public bool DisplaySecondLevel { get; set; }
	}
}
