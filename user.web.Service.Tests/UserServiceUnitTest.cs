using user.Web.Repository;
using user.Web.Services;
using System.Linq;
using FakeItEasy;
using Xunit;
using FluentAssertions;
using TestData;
using user.Web.Models;

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
        private readonly Users users;

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

        #region InsertKey
        [Fact]

        public async void InsertKeys_WithContent()
        {
            bool responseObj = true;
            A.CallTo(() => _userRepository.InsertKeys(A<Users>.Ignored)).Returns(responseObj);
            var response = await _userService.InsertKeys(users);
            response.Should().Be(responseObj);
        }

        [Fact]

        public async void InsertKeys_WithNoContent()
        {
            bool responseObj = false;
            A.CallTo(() => _userRepository.InsertKeys(A<Users>.Ignored)).Returns(responseObj);
            var response = await _userService.InsertKeys(users);
            response.Should().Be(responseObj);
        }
        #endregion

        #region DeleteAllKeys
        [Fact]

        public async void DeleteAllKeys_WithContent()
        {
            bool responseObj = true;
            A.CallTo(() => _userRepository.DeleteAllKeys()).Returns(responseObj);
            var response = await _userService.DeleteAllKeys();
            response.Should().Be(responseObj);
        }

        [Fact]

        public async void DeleteAllKeys_WithNoContent()
        {
            bool responseObj = false;
            A.CallTo(() => _userRepository.DeleteAllKeys()).Returns(responseObj);
            var response = await _userService.DeleteAllKeys();
            response.Should().Be(responseObj);
        }
        #endregion

        #region DeleteKeys
        [Fact]

        public async void DeleteKey_WithContent()
        {
            bool responseObj = true;
            A.CallTo(() => _userRepository.DeleteKey(A<int>.Ignored)).Returns(responseObj);
            var response = await _userService.DeleteKey(Id);
            response.Should().Be(responseObj);
        }

        [Fact]

        public async void DeleteKey_WithNoContent()
        {
            bool responseObj = false;
            A.CallTo(() => _userRepository.DeleteKey(A<int>.Ignored)).Returns(responseObj);
            var response = await _userService.DeleteKey(Id);
            response.Should().Be(responseObj);
        }
        #endregion

        #region UpdateKeys
        [Fact]

        public async void UpdateKeys_WithContent()
        {
            bool responseObj = true;
            A.CallTo(() => _userRepository.UpdateKeys(A<int>.Ignored, A<string>.Ignored, A<string>.Ignored, A<string>.Ignored)).Returns(responseObj);
            var response = await _userService.UpdateKeys(Id,Name,Username,Email);
            response.Should().Be(responseObj);
        }

        [Fact]

        public async void UpdateKeys_WithNoContent()
        {
            bool responseObj = false;
            A.CallTo(() => _userRepository.UpdateKeys(A<int>.Ignored, A<string>.Ignored, A<string>.Ignored, A<string>.Ignored)).Returns(responseObj);
            var response = await _userService.UpdateKeys(Id,Name,Username,Email);
            response.Should().Be(responseObj);
        }
        #endregion
    }
}