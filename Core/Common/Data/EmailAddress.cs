/**
 * Copyright (C) moniüs, 2010.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@monius.net
 */

namespace monius.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class EmailAddress : Core.Base.Object
	{
		/// <summary>
		/// validates provided string as email address,
		/// </summary>
		/// <param name="emailAddress"></param>
		/// <returns></returns>
		static public bool Validate(string emailAddress)
		{
			if (string.IsNullOrEmpty(emailAddress))
				return false;

			var regex = new System.Text.RegularExpressions.Regex(Configuration.EmailAddress.CheckPattern);
			var match = regex.Match(emailAddress);
			if (!match.Success)
				return false;

			string user = match.Groups["user"].Value;
			string host = match.Groups["host"].Value;

			return (user.Length >= 3) && (host.Length >= 3);
		}
	}
}