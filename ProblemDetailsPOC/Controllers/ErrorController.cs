using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProblemDetailsPOC.Extensions;
using ProblemDetailsPOC.Exceptions;

namespace ProblemDetailsPOC.Controllers;

[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController: ControllerBase
{
	[Route("/error")]
	public IActionResult HandleError()
	{
		var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

		if (exceptionHandlerFeature == null)
			return Problem();
		
		switch (exceptionHandlerFeature.Error)
		{
			case ValidationException valEx:
				return ValidationProblem(statusCode: StatusCodes.Status400BadRequest, modelStateDictionary: valEx.Errors.ToModelStateDictionary());
			
			case NotFoundException notFoundEx:
				return Problem(instance: $"entity/{notFoundEx.EntityId}", statusCode: StatusCodes.Status404NotFound);
			
			case ConflictException conflictEx:
				return this.Problem(statusCode: StatusCodes.Status409Conflict, errorCode: conflictEx.ErrorCode);
			
			default:
				return Problem(statusCode: StatusCodes.Status500InternalServerError);
		}
	}
}