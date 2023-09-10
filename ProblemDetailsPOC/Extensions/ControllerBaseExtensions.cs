using Microsoft.AspNetCore.Mvc;

namespace ProblemDetailsPOC.Extensions;

public static class ControllerBaseExtensions
{
	public static ObjectResult Problem(
		this ControllerBase controller,
		string? detail = null,
		string? instance = null,
		int? statusCode = null,
		string? title = null,
		string? type = null,
		string? errorCode = null)
	{
		var problemDetails = controller.ProblemDetailsFactory.CreateProblemDetails(
			controller.HttpContext,
			statusCode: statusCode ?? 500,
			title: title,
			type: type,
			detail: detail,
			instance: instance);

		problemDetails.Extensions.Add("errorCode", errorCode);

		return new ObjectResult(problemDetails)
		{
			StatusCode = problemDetails.Status
		};
	}
}