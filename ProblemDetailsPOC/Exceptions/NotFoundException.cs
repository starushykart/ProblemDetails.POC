namespace ProblemDetailsPOC.Exceptions;

public class NotFoundException: Exception
{
	public Guid EntityId { get; set; }
}