using AuthAPI.Repositories;
using MediatR;


namespace AuthAPI.Features.Activity.Commands;

public record DeleteActivityCommand(int Id) : IRequest<bool>;

public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, bool>
{
    private readonly IRepository<Models.Activity> _repository;

    public DeleteActivityCommandHandler(IRepository<Models.Activity> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var Activity = await _repository.GetByIdAsync(request.Id);
        if (Activity == null) return false;

        _repository.Delete(Activity);
        await _repository.SaveChangesAsync();
        return true;
    }
}
