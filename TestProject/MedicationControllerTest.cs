using Xunit;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MedicationRESTApi.Controllers;
using MedicationRESTApi.Contracts;
using MedicationRESTApi.Models;

namespace MedicationtControllerTest
{
    public class MedicationControllerTest
    {
        private readonly MedicationController _controller;
        private readonly IMedicationService _service;
        public MedicationControllerTest()
        {
            _service = new MedicationServiceFake();
            _controller = new MedicationController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllMedication()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Medication>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            //Act
            var notFoundResult = _controller.Get(Guid.NewGuid());
            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            // Act
            var okResult = _controller.Get(testGuid);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            // Act
            var okResult = _controller.Get(testGuid) as OkObjectResult;
            // Assert
            Assert.IsType<Medication>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Medication).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Medication()
            {
                Name = "Aspirine",
                Quantity = 1
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.Post(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Medication testItem = new Medication()
            {
                Name = "Guinness Original 6 Pack",
                Quantity = 1
            };
            // Act
            var createdResponse = _controller.Post(testItem);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Medication()
            {
                Name = "Guinness Original 6 Pack",
                Quantity = 1
            };
            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Medication;
            // Assert
            Assert.IsType<Medication>(item);
            Assert.Equal("Guinness Original 6 Pack", item.Name);
        }

        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();
            // Act
            var badResponse = _controller.Delete(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            // Act
            var noContentResponse = _controller.Delete(existingGuid);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            // Act
            var okResponse = _controller.Delete(existingGuid);
            // Assert
            Assert.Equal(1, _service.GetAllMedications().Count());
        }
    }
}