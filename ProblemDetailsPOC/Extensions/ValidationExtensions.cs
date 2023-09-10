using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProblemDetailsPOC.Extensions;

public static class ValidationExtensions
{
	public static ModelStateDictionary ToModelStateDictionary(this IEnumerable<ValidationFailure> errors)
	{
		var modelStateDictionary = new ModelStateDictionary();
		foreach (var error in errors)
		{
			modelStateDictionary.AddModelError(error.PropertyName, error.ErrorMessage);
		}

		return modelStateDictionary;
	}
}