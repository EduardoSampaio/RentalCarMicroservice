using Scheduling.Domain.DomainModel.Core;

namespace Scheduling.Domain.DomainModel.ValueObjects;
public class DateStartEnd: ValueObject
{
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }

    public DateStartEnd(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssertionConcern.AssertDateTimeMoreThanOrEqualsToday(startDate, "Start Date must more than current date");
        AssertionConcern.AssertDateTimeMoreThanOrEqualsToday(endDate, "End Date must be more than current date");
        AssertionConcern.AssertDateTimeCompare(startDate, endDate, "End Date must more than Start Date");
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
