using com.dyeingprinting.service.content.api.Controllers;
using com.dyeingprinting.service.content.business;
using com.dyeingprinting.service.content.data.Model;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace com.dyeingprinting.service.content.api.Test
{
    [TestClass]
    public class CustomerCareTest
    {
        private readonly Mock<ILogger<CustomerCareController>> _logger;
        private readonly Mock<IService<CustomerCare>> _service;

        public CustomerCareTest()
        {
            _logger = new Mock<ILogger<CustomerCareController>>();
            _service = new Mock<IService<CustomerCare>>();
        }

        public CustomerCareController GetController()
        {
            var controller = new CustomerCareController(_service.Object,_logger.Object);
            return controller;
        }

        public CustomerCare Data = new CustomerCare
        {
            Title = "Test",
            ContentTitle1 = "Test",
            ContentUrl1 = "Test",
            ContentDescription1 ="Test",
            TextButton1 ="Test",
            ImageUrl1 ="Test"
        };

        [TestMethod]
        public async Task Post_Test()
        {
            var controller = GetController();
            var result = controller.Post(Data).Result;
        }

        [TestMethod]
        public async Task FindAsync_Test()
        {
            var controller = GetController();
            var result = controller.FindAsync().Result;
        }

        [TestMethod]
        public async Task Delete_Test()
        {
            var controller = GetController();
            var result = controller.Delete(Data.Id).Result;
        }

        [TestMethod]
        public async Task Update_Test()
        {
            var controller = GetController();
            var result = controller.Put(Data.Id, Data).Result;
        }
    }
}
