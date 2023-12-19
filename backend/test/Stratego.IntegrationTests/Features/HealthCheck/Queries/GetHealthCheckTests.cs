using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Stratego.Features.HealthCheck.Queries;

namespace Stratego.IntegrationTests.Features.HealthCheck.Queries;

public sealed class GetHealthCheckTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetHealthCheck_Should_Return_Ok_When_Successful()
    {
        // Arrange
        using var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("api/health-check");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadFromJsonAsync<GetHealthCheck.Result>();
        Assert.NotNull(content);
        Assert.Equal("OK", content.Message);
    }
}