// -----------------------------------------------------------------------
// <copyright file="Helpers.cs" company="">
// </copyright>
// -----------------------------------------------------------------------

namespace Optional.Tests
{
	using System;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	internal class Helpers
	{
		internal class Address
		{
			internal string AddressLine1
			{
				get;
				set;
			}
		}

		internal class Person
		{
			internal Address Address
			{
				get;
				set;
			}
		}

		internal class Employee
		{
			internal Person Person
			{
				get;
				set;
			}
		}
	}
}
