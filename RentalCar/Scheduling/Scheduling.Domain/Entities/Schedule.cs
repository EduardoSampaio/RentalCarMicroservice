using Scheduling.Domain.Core;
using Scheduling.Domain.ValueObjects;

namespace Scheduling.Domain.Entities;
public class Schedule : Entity
{
    public DateStartEnd DateStartEnd { get; private set; }
    public decimal TotalPay { get; private set; }
    public bool IsSamePlace { get; private set; }
    public string PickUpLocation { get; set; } = string.Empty;
    public string? ReturnLocation { get; set; }
    public int CarCategoryId { get; private set; }
    public Category CarCategory { get; private set; }

    public Schedule(DateTime startDate, DateTime endDate, string pickUpLocation, string? returnLocation, Category carCategory)
    {
        DateStartEnd = new DateStartEnd(startDate, endDate);
        PickUpLocation = pickUpLocation;
        ReturnLocation = returnLocation;
        TotalPay = CalculateTotalPay();
        CarCategory = carCategory;
        CarCategoryId = CarCategory.Id;
    }

    public Schedule(DateTime startDate, DateTime endDate, string pickUpLocation, bool isSamePlace, Category carCategory)
    {
        DateStartEnd = new DateStartEnd(startDate, endDate);
        PickUpLocation = pickUpLocation;
        IsSamePlace = isSamePlace;
        TotalPay = CalculateTotalPay();
        CarCategory = carCategory;
        CarCategoryId = CarCategory.Id;
    }

    private decimal CalculateTotalPay()
    {
        if (CarCategory is null)
            throw new Exception("Car Category Is Null");

        return CarCategory.TotalPerDay * DateStartEnd.NumberOfDays();
    }

    public void ChangeDateStarEnd(DateTime startDate, DateTime endDate)
    {
        DateStartEnd = new DateStartEnd(startDate, endDate);
        TotalPay = CalculateTotalPay();
    }

    public void ChangeCategory(Category carCategory)
    {
        CarCategory = carCategory;
        CarCategoryId = carCategory.Id;
    }
}
