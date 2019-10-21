using Microsoft.AspNetCore.Mvc.Testing;
using Pica.Taller.Mvc;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace WebTest
{
    public class PagesTest
    : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PagesTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Members")]
        [InlineData("/Members/Contact")]
        [InlineData("/Members/Acknowledgment")]
        [InlineData("/Members/RaiseException")]
        public async Task Get_PageNoErrorAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.NotEqual("/Home/Error", response.RequestMessage.RequestUri.LocalPath);
        }

        [Theory]
        [InlineData("/TestPageNotExists")]
        public async Task Get_PageNoErrorAndNoExists(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.Equal("/Home/Error?code=404", response.RequestMessage.RequestUri.PathAndQuery);
        }

        [Theory]
        [InlineData("/Members")]
        [InlineData("/Members/Contact")]
        [InlineData("/Members/Acknowledgment")]
        [InlineData("/Members/RaiseException")]
        public async Task Get_SecurePageRequiresAnAuthenticatedUser(string url)
        {
            // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Login", response.Headers.Location.AbsolutePath);
        }
    }
}