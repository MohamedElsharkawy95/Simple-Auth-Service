using AuthAPI.Models;
using AuthAPI.Repositories;
using MediatR;

namespace AuthAPI.Features.Product.Queries;

public record GetActivityByIdQuery(int Id) : IRequest<Models.Activity?>;

public class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, Models.Activity?>
{
    private readonly IRepository<Models.Activity> _repository;

    public GetActivityByIdQueryHandler(IRepository<Models.Activity> repository)
    {
        _repository = repository;
    }

    public async Task<Models.Activity?> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}

