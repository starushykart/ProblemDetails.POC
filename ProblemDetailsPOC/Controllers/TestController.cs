using Microsoft.AspNetCore.Mvc;

namespace ProblemDetailsPOC.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
	// all of these responses are returned in ProblemDetails format
	
	[HttpGet("bad-request")]
	public IActionResult BadRequestAction()
		=> BadRequest();

	[HttpGet("not-found")]
	public IActionResult NotFoundAction()
		=> NotFound();

	[HttpGet("conflict")]
	public IActionResult ConflictAction()
		=> Conflict();
	
	[HttpGet("unprocessable-entity")]
	public IActionResult UnprocessableEntityAction()
		=> UnprocessableEntity();
}