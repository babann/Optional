using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Optional.Tests
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class UnitTest
	{
		const string DEFAULT_ADDR1 = "no address";
		const string GOOD_ADDR1 = "correct address";

		static Helpers.Employee BadEmployee;
		static Helpers.Employee GoodEmployee;

		public UnitTest()
		{

		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[ClassInitialize()]
		public static void MyClassInitialize(TestContext testContext)
		{
			BadEmployee = new Helpers.Employee();
			GoodEmployee = new Helpers.Employee()
			{
				Person = new Helpers.Person()
				{
					Address = new Helpers.Address()
					{
						AddressLine1 = GOOD_ADDR1
					}
				}
			};
		}

		[TestMethod]
		public void Test_BadGenericMapGet()
		{
			string result = OptionalDemo.Optional<string>.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).Get();

			Assert.IsNull(result);
		}

		[TestMethod]
		public void Test_BadGenericMapGetOrDefault()
		{
			string result = OptionalDemo.Optional<string>.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.AreEqual(result, DEFAULT_ADDR1);
		}

		[TestMethod]
		public void Test_BadGenericMapGetAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional<string>.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).Get();

			Assert.IsNull(result);
			Assert.IsNotNull(errormsg);
		}

		[TestMethod]
		public void Test_BadGenericMapGetOrDefaultAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional<string>.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.IsNotNull(errormsg);
			Assert.AreEqual(result, DEFAULT_ADDR1);
		}

		[TestMethod]
		public void Test_BadMapGet()
		{
			string result = OptionalDemo.Optional.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).Get();

			Assert.IsNull(result);
		}

		[TestMethod]
		public void Test_BadMapGetOrDefault()
		{
			string result = OptionalDemo.Optional.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.AreEqual(result, DEFAULT_ADDR1);
		}

		[TestMethod]
		public void Test_BadMapGetAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).Get();

			Assert.IsNull(result);
			Assert.IsNotNull(errormsg);
		}

		[TestMethod]
		public void Test_BadMapGetOrDefaultAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional.Map(() => { return BadEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.IsNotNull(errormsg);
			Assert.AreEqual(result, DEFAULT_ADDR1);
		}

		[TestMethod]
		public void Test_GoodGenericMapGet()
		{
			string result = OptionalDemo.Optional<string>.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).Get();

			Assert.IsNotNull(result);
			Assert.AreEqual(result, GOOD_ADDR1);
		}

		[TestMethod]
		public void Test_GoodGenericMapGetOrDefault()
		{
			string result = OptionalDemo.Optional<string>.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.AreEqual(result, GOOD_ADDR1);
		}

		[TestMethod]
		public void Test_GoodGenericMapGetAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional<string>.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).Get();

			Assert.IsNotNull(result);
			Assert.AreEqual(result, GOOD_ADDR1);
			Assert.IsNull(errormsg);
		}

		[TestMethod]
		public void Test_GoodGenericMapGetOrDefaultAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional<string>.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.IsNull(errormsg);
			Assert.AreEqual(result, GOOD_ADDR1);
		}

		[TestMethod]
		public void Test_GoodMapGet()
		{
			string result = OptionalDemo.Optional.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).Get();

			Assert.IsNotNull(result);
			Assert.AreEqual(result, GOOD_ADDR1);
		}

		[TestMethod]
		public void Test_GoodMapGetOrDefault()
		{
			string result = OptionalDemo.Optional.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.AreEqual(result, GOOD_ADDR1);
		}

		[TestMethod]
		public void Test_GoodMapGetAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).Get();

			Assert.IsNotNull(result);
			Assert.AreEqual(result, GOOD_ADDR1);
			Assert.IsNull(errormsg);
		}

		[TestMethod]
		public void Test_GoodMapGetOrDefaultAndException()
		{
			string errormsg = null;
			string result = OptionalDemo.Optional.Map(() => { return GoodEmployee.Person.Address.AddressLine1; }).OnError((exc) => { errormsg = exc.Message; }).GetOrDefault(DEFAULT_ADDR1);

			Assert.IsNotNull(result);
			Assert.IsNull(errormsg);
			Assert.AreEqual(result, GOOD_ADDR1);
		}
	}
}
