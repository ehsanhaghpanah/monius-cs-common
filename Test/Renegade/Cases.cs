/**
 * Copyright (C) moniüs, 2008.
 * All rights reserved.
 * E. Haghpanah; haghpanah@monius.net
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Renegade
{

	[TestClass]
	public class Tester
	{
		[TestMethod]
		public void foo()
		{
			Console.WriteLine("OK");

			Console.WriteLine(monius.Common.MobileNumber.Validate("+989177918559"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("0917 791 8559"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("0917-7918559"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("0917-791(8559)"));

			Console.WriteLine(monius.Common.MobileNumber.Validate("09177918559"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09900000000"));
			Console.WriteLine(monius.Common.MobileNumber.Validate("09800000000"));
		}
	}
}