/**
 * Copyright (C) moniüs, 2010.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@monius.net
 */

using System.Text;

namespace monius.Common
{
	/// <summary>
	/// <c>Security ID</c> validator,
	/// </summary>
	public class SecurityID : Core.Base.Object
	{
		/// <summary>
		/// validates provided string as <c>Security ID</c>,
		/// </summary>
		/// <param name="securityID"></param>
		/// <returns></returns>
		static public bool Validate(string securityID)
		{
			if (string.IsNullOrEmpty(securityID))
				return false;

			var temp = new StringBuilder();
			foreach (var c in securityID)
				if (char.IsDigit(c))
					temp.Append(c);

			return (temp.ToString().Length > 0);
		}
	}
}