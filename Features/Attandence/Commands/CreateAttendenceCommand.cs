
using AuthAPI.Enums;
using AuthAPI.Models;
using AuthAPI.Repositories;
using MediatR;

namespace AuthAPI.Features.Product.Commands;

public record CreateActivityCommand(string Description, double Grade, string AttendanceStatus, int StudentId, int ClassId) : IRequest<int>;

public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, int>
{
    private readonly IRepository<Models.Activity> _repository;
    private readonly IRepository<StudentClass> _studentClassRepository;

    public CreateActivityCommandHandler(IRepository<Models.Activity> repository, IRepository<StudentClass> studentClassRepository)
    {
        _repository = repository;
        _studentClassRepository = studentClassRepository;
    }

    public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var studentClasses = await _studentClassRepository.GetAllAsync();
        var studentClass = studentClasses.FirstOrDefault(s => s.ClassId == request.ClassId && s.UserId == request.StudentId);
        if (studentClass == null) return 0;

        Enum.TryParse(request.AttendanceStatus, out AttendanceStatus status);

        var activity = new Models.Activity
        {
            Description = request.Description,
            ActivityType = ActivityType.Attendance,
            Date = DateTime.UtcNow,
            AttendanceStatus = status,
            StudentClassId = studentClass.Id,
            Grade = request.Grade,
        };
        await _repository.AddAsync(activity);
        await _repository.SaveChangesAsync();
        return activity.Id;
    }
}