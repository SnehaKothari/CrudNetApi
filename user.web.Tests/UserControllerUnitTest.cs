using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestData;
using user.Web.Controllers;
using user.Web.Services;
using Xunit;
using NUnit.Framework;

namespace user.web.Tests
{
    public class UserControllerUnitTest
    {
        private readonly UserController _userController;
        private readonly IUserService _userService;

        public UserControllerUnitTest()
        {
            _userService = A.Fake<IUserService>();
            var httpContext = new DefaultHttpContext();
            _userController = new UserController(_userService)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
        }

        private readonly int Id = 1;
        private readonly string Name = "Sneha Kothari";
        private readonly string Username = "sneha";
        private readonly string Email = "kothari.sneha05@gmail.com";


        #region GetAllKeys
        [Fact]

        public void GetAllKeys_withData()
        {
            A.CallTo(() => _userService.GetAllKeys()).Returns(Test.GetAllKeys());
            var response = _userController.GetAllKeys().Result;
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion


        
        #region GetKey
        [Fact]

        public void GetKey_withData()
        {
            A.CallTo(() => _userService.GetKey(Id)).Returns(Test.GetKey());
            var response = _userController.GetKey(Id).Result;
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion
    }
}

