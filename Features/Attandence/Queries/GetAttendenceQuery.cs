using AuthAPI.Models;
using AuthAPI.Repositories;
using MediatR;

namespace AuthAPI.Features.Product.Queries;

public record GetAttendenceQuery() : IRequest<IEnumerable<Models.Activity>>;

public class GetProductsQueryHandler : IRequestHandler<GetAttendenceQuery, IEnumerable<Models.Activity>>
{
    private readonly IRepository<Models.Activity> _repository;

    public GetProductsQueryHandler(IRepository<Models.Activity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Models.Activity>> Handle(GetAttendenceQuery request, CancellationToken cancellationToken)
    {
        var results = await _repository.GetAllAsync();
        return results.Where(a => a.ActivityType == Enums.ActivityType.Attendance);
    }
}
