using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ProblemDetailsPOC.Exceptions;

namespace ProblemDetailsPOC.Controllers;

[ApiController]
[Route("error-handling-example")]
public class ErrorHandlingExampleController : ControllerBase
{
	// all of these responses are returned in ProblemDetails format

	[HttpGet("bad-request")]
	public IActionResult BadRequestAction()
		=> throw new ValidationException("Validation failed", new[] { new ValidationFailure("testProp", "testError")});

	[HttpGet("not-found")]
	public IActionResult NotFoundAction()
		=> throw new NotFoundException();

	[HttpGet("conflict")]
	public IActionResult ConflictAction()
		=> throw new ConflictException { ErrorCode = "some error code"};
	
	[HttpGet("other")]
	public IActionResult UnprocessableEntityAction()
		=> throw new OtherException();
}