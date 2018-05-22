using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDC.UI;
using NDC.UI.Controllers;
using NDC.UI.SoapServiceReference;
using System.Threading.Tasks;

namespace NDC.UI.UTest.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        [Description("Validate model")]
        public async Task Index()
        {
            // Arrange
            var controller = new HomeController();
            var model = new SearchModel();

            // Act
            var result = await controller.Index(model);

            // Assert
            Assert.IsNotNull(result,"Validated");
        }

        [TestMethod]
        [Description("Search model")]
        public async Task Index1()
        {
            // Arrange
            var controller = new HomeController();
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

            // Act
            var result = await controller.Index(model);

            // Assert
            Assert.IsNotNull(result,"Search success");
        }

    }
}
