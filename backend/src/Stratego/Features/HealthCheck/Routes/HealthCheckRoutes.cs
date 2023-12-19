﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stratego.Features.HealthCheck.Queries;

namespace Stratego.Features.HealthCheck.Routes;

public static class HealthCheckRoutes
{
    public static void ConfigureHealthCheckRoutes(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/api/health-check", async ([FromServices] IMediator mediator) =>
            {
                var result = await mediator.Send(new GetHealthCheck.Query());
                return Results.Ok(result);
            })
            .WithOpenApi()
            .Produces<GetHealthCheck.Result>();
    }
}