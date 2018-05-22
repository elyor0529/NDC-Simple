using NUnit.Framework;

namespace NDC.Infrastructure.NUnit
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class TestClass
    {
        private readonly ApplicationDbContext _db;

        public TestClass()
        {
            _db = ApplicationDbContext.Create();
        }

        [Test]
        [Description("Db migrate")]
        public void TestMethod1()
        {
            ApplicationDbContext.Initializer();

            Assert.Pass("Migration success!");
        }

        [Test]
        [Description("Search people")]
        public async Task TestMethod2()
        {
            //names,gender and country
            var query = await _db.People.Where(w => w.FullName.Contains("John") || w.Gender.Equals("Male") || w.Country.Contains("USA")).ToArrayAsync();

            Assert.True(query.Length > 0, "Search found({0} items)", query.Length);
        }


    }
}
