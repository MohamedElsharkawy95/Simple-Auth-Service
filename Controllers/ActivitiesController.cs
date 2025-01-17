using AuthAPI.Features.Activity.Commands;
using AuthAPI.Features.Product.Commands;
using AuthAPI.Features.Product.Queries;
using AuthAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAttendenceQuery());
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetById([FromRoute] int id)
    {
        var activity = await _mediator.Send(new GetActivityByIdQuery(id));
        if (activity == null) return NotFound();
        return Ok(activity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateActivityCommand command)
    {
        var activityId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = activityId }, null);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateActivityCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteActivityCommand(id));
        if (!result) return NotFound();

        return NoContent();
    }
}
