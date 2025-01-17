using AuthAPI.Repositories;
using AuthAPI.Models;
using MediatR;
using AuthAPI.Enums;

namespace AuthAPI.Features.Product.Commands;

public record UpdateActivityCommand(int Id, string Description, double Grade, string AttendanceStatus) : IRequest<bool>;

public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, bool>
{
    private readonly IRepository<Models.Activity> _repository;

    public UpdateActivityCommandHandler(IRepository<Models.Activity> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _repository.GetByIdAsync(request.Id);
        if (activity == null) return false;

        activity.Description = request.Description;
        activity.Grade = request.Grade;
        Enum.TryParse(request.AttendanceStatus, out AttendanceStatus status);
        activity.AttendanceStatus = status;

        _repository.Update(activity);
        await _repository.SaveChangesAsync();
        return true;
    }
}