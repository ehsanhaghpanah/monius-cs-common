/**
 * Copyright (C) moniüs, 2010.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@monius.net
 */

using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using monius.Core.Common;

namespace monius.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class MobileNumber : Core.Base.Object
	{
		/// <summary>
		/// validates provided string as a mobile number,
		/// </summary>
		/// <param name="mobileNumber"></param>
		/// <returns></returns>
		static public bool Validate(string mobileNumber)
		{
			try
			{
				//
				// general validation pattern;
				// (0|\+98)?([ ]|-|[()]){0,2}9[0|1|2|3|4|9]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}
				// restricted validation pattern;
				// (0|\+98)9[0|1|2|3|9]{1}[0-9]{8} 
				//

				if (string.IsNullOrEmpty(mobileNumber))
					return false;

				var regex = new System.Text.RegularExpressions.Regex(Configuration.MobileNumber.CheckPattern);
				var match = regex.Match(mobileNumber);
				return match.Success;
			}
			catch (Exception p)
			{
				logger.Error(JsonConvert.SerializeObject(new
				{
					m = "Validate (MobileNumber)",
					a = new { value = mobileNumber },
					p
				}, Formatting.Indented));
				return false;
			}
		}

		/// <summary>
		/// uniforms mobile number to <c>{<see cref="CountryCode"/>CountryCode}</c><c>{<see cref="MobileOperator"/>MobileOperator}</c>{rrr}{nnnn} 
		/// where <c>rrr</c> may identify region and <c>nnnn</c> may represent actual subscriber identifier,
		/// </summary>
		/// <param name="mobileNumber">mobile number to be uniformed</param>
		/// <returns>uniformed representation of provided mobile number</returns>
		static public MobileNumber Uniform(string mobileNumber)
		{
			if (!Validate(mobileNumber))
				throw new CommonValidationException(ResourceObjects.MobileNumberIsNotValid);

			return mobileNumber.StartsWith("0")
				? new MobileNumber { MSISDN = "+98" + mobileNumber.Substring(1) }
				: new MobileNumber { MSISDN = mobileNumber };
		}

		private MobileNumber()
		{
		}

		#region MobileNumber

		/// <summary>
		/// 
		/// </summary>
		protected CountryCode Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		protected MobileOperator Operator { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MSISDN { get; protected set; }

		#endregion

		#region MobileNumber

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return MSISDN;
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		public class CountryCode
		{
			private static readonly List<string> _CountryCodes = new List<string> { "+98" };

			public CountryCode(string code)
			{
				if (!code.StartsWith("+"))
					code = "+" + code;

				if (!_CountryCodes.Contains(code))
					throw new CommonValidationException(ResourceObjects.CountryCodeNotFound);

				Code = code;
			}

			public string Code { get; private set; }
		}

		/// <summary>
		/// 
		/// </summary>
		public class MobileOperator
		{
			public MobileOperator(CountryCode countryCode, string code)
			{
			}

			public string Code { get; set; }
		}
	}
}