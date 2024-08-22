using Microsoft.AspNetCore.Mvc.Testing;
using TaskManagmetApi;

namespace TestTaskManage.WebApplicationFactory
{
    public class WebApplicationFactoryIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public WebApplicationFactoryIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTask_ReturnsTaks_ById()
        {
            // Act
            HttpResponseMessage? response = await _client.GetAsync("/Task/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("Estudiar", content);
        }
    }
}
