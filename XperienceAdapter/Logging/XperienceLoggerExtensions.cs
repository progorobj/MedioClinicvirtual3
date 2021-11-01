using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace XperienceAdapter.Logging
{
	public static class XperienceLoggerExtensions
	{
		public static ILoggingBuilder AddXperience(this ILoggingBuilder builder)
		{
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, XperienceLoggerProvider>());

			return builder;
		}

		public static void LogEvent(this ILogger logger, LogLevel logLevel, string? methodName, string? message = default, Exception? exception = default, params object[] args)
		{
			if (!string.IsNullOrEmpty(methodName))
			{
				var eventId = new EventId(0, methodName);

				logger.Log(logLevel, eventId, exception, message, args);
			}
			else
			{
				logger.Log(logLevel, exception, message, args);
			}
		}
	}
}
