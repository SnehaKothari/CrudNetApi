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
using user.Web.Models;

namespace user.web.Tests
{
    public class UserControllerUnitTest
    {
        private readonly UserController _userController;
        private readonly IUserService _userService;
    //
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
        private readonly Users users;


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
        #region GetMoq
        /* public async void GetAllKeys_ShouldReturnResponse_WhenDataFound()
           {
               var response = _fixture.Create<IEnumerable<Users>>();
               _userservice.Setup(x => x.GetAllKeys()).ReturnsAsync(response);

               //Act
               var result = await _userController.GetAllKeys().ConfigureAwait(false);
               //Assert.NotNull(result);
               result.Should().NotBeNull();
               result.Should().BeAssignableTo<ActionResult<IEnumerable<Users>>>();
               result.Should().BeAssignableTo<OkObjectResult>();
               result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeOfType(response.GetType());
               _userservice.Verify(x => x.GetAllKeys(), Times.Once());

           }*/
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

        #region InsertKey
        [Fact]

        public void InsertKeys_withData()
        {
            bool responseObj = true;
            A.CallTo(() => _userService.InsertKeys(A<Users>.Ignored)).Returns(responseObj);
            var response = _userController.InsertKeys(users).Result;
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion

        #region DeleteAllKeys
        [Fact]

        public void DeleteAllKeys_withData()
        {
            bool responseObj = true;
            A.CallTo(() => _userService.DeleteAllKeys()).Returns(responseObj);
            var response = _userController.DeleteAllKeys().Result;
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion


        #region DeleteKey
        [Fact]

        public void DeleteKey_withData()
        {
            bool responseObj = true;
            A.CallTo(() => _userService.DeleteKey(A<int>.Ignored)).Returns(responseObj);
            var response = _userController.DeleteKey(Id).Result;
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion

        #region UpdateKey
        [Fact]

        public void UpdateKeys_withData()
        {
            bool responseObj = true;
            A.CallTo(() => _userService.UpdateKeys(A<int>.Ignored,A<string>.Ignored,A<string>.Ignored,A<string>.Ignored)).Returns(responseObj);
            var response = _userController.UpdateKeys(Id,Name,Username,Email).Result;
            var result = response as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        #endregion

    }
}
