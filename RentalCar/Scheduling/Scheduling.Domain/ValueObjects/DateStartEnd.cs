using Scheduling.Domain.Core;

namespace Scheduling.Domain.ValueObjects;
public class DateStartEnd : ValueObject
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public DateStartEnd()
    {
        
    }

    public DateStartEnd(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public int NumberOfDays()
    {
        return (EndDate - StartDate).Days;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartDate;
        yield return EndDate;
    }
}
