/**
 * Copyright (C) moniüs, 2013.
 * All rights reserved.
 * Ehsan Haghpanah; haghpanah@monius.net
 */

using System;

namespace Renegade
{
	/// <summary>
	/// 
	/// </summary>
	static public class Program
	{
		[STAThread]
		static public void Main()
		{
			Console.WriteLine(monius.Common.MobileNumber.Validate("09150000000"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09177918559"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09100000000"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09200000000"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09900000000"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09800000000"));
		}
	}
}