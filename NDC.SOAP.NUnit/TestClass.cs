using NUnit.Framework;

namespace NDC.SOAP.NUnit
{
    using SoapServiceReference;
    using System.Threading.Tasks;

    [TestFixture]
    public class TestClass
    {
        private readonly PersonServiceClient _client;

        public TestClass()
        {
            _client = new PersonServiceClient();
        }

        [Test]
        [Description("Validate model")]
        public async Task TestMethod1()
        {
            var model = new SearchModel();

            await _client.SearchAsync(model);

            Assert.Pass("Search is success");
        }

        [Test]
        [Description("Creterial search")]
        public async Task TestMethod2()
        {
            var model = new SearchModel
            {
                Names = "John",
                DestinationEmail = "elyor@outlook.com",
                MaxAge = 100,
                MinAge = 5,
                MaxHeigth = 250,
                MaxWeight = 150,
                MinHeigth = 50,
                MinWeight = 50,
                Nationality = "USA",
                Sex = "Male"
            };
            var result = await _client.SearchAsync(model);

            Assert.True(result > 0, "Search found {0} result(s)", result);
        }

    }
}
