using System;
using Xunit;
using Compass.Api.Core.Controllers;
using Compass.Service.Core;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Compass.Domain;
using System.Collections.Generic;

namespace Compass.Api.Unit.Test.Core
{
    public class SurveyControllerTest
    {
        SurveyController _controller;
        ISurveyService _service;
        ILogger<SurveyController> _logger;

        public SurveyControllerTest()
        {
            _service = new SurveyServiceFake();
            _controller = new SurveyController(_service);
        }
        
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get("2").Result as OkObjectResult;
            // Assert
            var item = Assert.IsType<Survey>(okResult.Value);
            Assert.Equal("Survey 2", item.Name);
            Assert.Equal(2, item.Questions.Count);
        }
    }
}
