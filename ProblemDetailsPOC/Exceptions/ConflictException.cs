namespace ProblemDetailsPOC.Exceptions;

public class ConflictException : Exception
{
	public string ErrorCode { get; set; }
}