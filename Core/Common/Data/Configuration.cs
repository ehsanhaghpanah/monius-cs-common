/**
 * Copyright (C) moniüs, 2010.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@monius.net
 */

using System.Configuration;
using monius.Core.Common;

namespace monius.Common
{
	/// <summary>
	/// 
	/// </summary>
	static public class Configuration
	{
		private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		/// <summary>
		/// 
		/// </summary>
		static public class MobileNumber
		{
			public static string CheckPattern
			{
				get
				{
					const string title = "monius:Common:MobileNumber:CheckPattern";
					var value = ConfigurationManager.AppSettings[title];
					if (value == null)
					{
						logger.Warn("ConfigurationIsMissing:{0}", title);
						return @"(0|\+98)9[0|1|2|3|9]{1}[0-9]{8}";
					}

					return value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		static public class EmailAddress
		{
			public static string CheckPattern
			{
				get
				{
					const string title = "monius:Common:EmailAddress:CheckPattern";
					var value = ConfigurationManager.AppSettings[title];
					if (value == null)
					{
						logger.Warn("ConfigurationIsMissing:{0}", title);
						return @"(?<user>[^@]+)@(?<host>.+)";
					}

					return value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		static public class NationalID
		{
			public static string CheckPattern
			{
				get
				{
					const string title = "monius:Common:NationalID:CheckPattern";
					var value = ConfigurationManager.AppSettings[title];
					if (value == null)
						throw new ConfigurationMissingException(string.Format("ConfigurationIsMissing:{0}", title));

					return value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		static public class SecurityID
		{
			public static string CheckPattern
			{
				get
				{
					const string title = "monius:Common:SecurityID:CheckPattern";
					var value = ConfigurationManager.AppSettings[title];
					if (value == null)
						throw new ConfigurationMissingException(string.Format("ConfigurationIsMissing:{0}", title));

					return value;
				}
			}
		}
	}
}