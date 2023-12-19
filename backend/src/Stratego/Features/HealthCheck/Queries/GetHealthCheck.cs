using MediatR;

namespace Stratego.Features.HealthCheck.Queries;

public static class GetHealthCheck
{
    public sealed record Query : IRequest<Result>;
    public sealed record Result(string Message);

    public sealed class Handler : IRequestHandler<Query, Result>
    {
        public Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Result("OK"));
        }
    }
}