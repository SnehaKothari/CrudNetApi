
using user.Web.Repository;
using user.Web.Services;
using System.Linq;
using FakeItEasy;
using Xunit;
using FluentAssertions;
using TestData;
using NUnit.Framework;


namespace user.web.Service.Tests
{
    public class UserServiceUnitTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserServiceUnitTest()
        {
            _userRepository = A.Fake<IUserRepository>();
            _userService = new UserService(_userRepository);
        }
        private readonly int Id = 1;
        private readonly string Name = "Sneha Kothari";
        private readonly string Username = "sneha";
        private readonly string Email = "kothari.sneha05@gmail.com";

        #region GetAllKeys
        [Fact]

        public async void GetAllKeys_WithContent()
        {
            A.CallTo(() => _userRepository.GetAllKeys()).Returns(Test.GetAllKeys());
            var response = await _userService.GetAllKeys();
            response.Count().Should().Be(2);
        }

        [Fact]

        public async void GetAllKeys_WithNoContent()
        {
            A.CallTo(() => _userRepository.GetAllKeys()).Returns(Test.GetAllKeys_NoContent());
            var response = await _userService.GetAllKeys();
            response.Count().Should().Be(0);
        }

        #endregion

        #region GetKey
        [Fact]

        public async void GetKey_WithContent()
        {
            A.CallTo(() => _userRepository.GetKey(A<int>.Ignored)).Returns(Test.GetKey());
            var response = await _userService.GetKey(Id);
            response.Count().Should().Be(1);
        }

        [Fact]

        public async void GetKey_WithNoContent()
        {
            A.CallTo(() => _userRepository.GetKey(A<int>.Ignored)).Returns(Test.GetKey_NoContent());
            var response = await _userService.GetKey(Id);
            response.Count().Should().Be(0);
        }
        #endregion
    }
}