/**
 * Copyright (C) moniüs, 2010.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@monius.net
 */

using System.Linq;
using System.Text;

namespace monius.Common
{
	/// <summary>
	/// <c>National ID</c> validator,
	/// </summary>
	public class NationalID : Core.Base.Object
	{
		/// <summary>
		/// validates provided string as <c>National ID</c>,
		/// </summary>
		/// <param name="nationalID"></param>
		/// <returns></returns>
		static public bool Validate(string nationalID)
		{
			if (string.IsNullOrEmpty(nationalID))
				return false;

			var temp = new StringBuilder();
			foreach (var c in nationalID.Where(char.IsDigit))
				temp.Append(c);

			if (temp.ToString().Length != 10)
				return false;

			var list = new[]
			{
				"0000000000",
				"1111111111",
				"2222222222",
				"3333333333",
				"4444444444",
				"5555555555",
				"6666666666",
				"7777777777",
				"8888888888",
				"9999999999"
			};

			if (list.Any(item => temp.ToString().Equals(item)))
				return false;

			var check_digit = int.Parse(temp.ToString().Substring(9, 1));
			var sum = 0;
			for (var i = 0; i < 9; i++)
				sum += (int.Parse(temp.ToString().Substring(i, 1)) * (10 - i));
			var mod = sum % 11;
			if (mod < 2)
				return (check_digit == mod);

			return (check_digit == (11 - mod));
		}

		/// <summary>
		/// only purifies provided string from non digit characters 
		/// and checks if its remaining string length is equal to 10,
		/// </summary>
		/// <param name="nationalID"></param>
		/// <returns></returns>
		static public string GetValidatedValue(string nationalID)
		{
			if (string.IsNullOrEmpty(nationalID))
				return "";

			var temp = new StringBuilder();
			foreach (var c in nationalID.Where(char.IsDigit))
				temp.Append(c);

			return (temp.ToString().Length == 10) ? temp.ToString() : "";
		}
	}
}