using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace QuickStart.Tests
{
    [Collection("Integration Tests")]
    public class DefaultControllerTests
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        public DefaultControllerTests(WebApplicationFactory<Startup> factory)
        {
            webApplicationFactory = factory;
        }

        [Fact]
        public async Task GetRoot_ReturnSuccessAndStartup()
        {
            //Arrange
            var client = webApplicationFactory.CreateClient();

            //Act
            var response = await client.GetAsync("/");

            //Asssert
            response.EnsureSuccessStatusCode();

            Assert.NotNull(response.Content);

            var responseObject = JsonSerializer.Deserialize<ResponseType>(
                await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive=true}
                );
            Assert.Equal("Up", responseObject?.Status);
        }

        private class ResponseType
        {
            public string Status { get; set; }
        }
    }
}
