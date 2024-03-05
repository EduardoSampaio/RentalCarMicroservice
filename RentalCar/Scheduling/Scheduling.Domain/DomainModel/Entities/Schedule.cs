using Scheduling.Domain.DomainModel.Core;
using Scheduling.Domain.DomainModel.ValueObjects;

namespace Scheduling.Domain.DomainModel.Entities;
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
        Validate();
    }

    public Schedule(DateTime startDate, DateTime endDate, string pickUpLocation, bool isSamePlace, Category carCategory)
    {
        DateStartEnd = new DateStartEnd(startDate, endDate);
        PickUpLocation = pickUpLocation;
        IsSamePlace = isSamePlace;
        TotalPay = CalculateTotalPay();
        CarCategory = carCategory;
        CarCategoryId = CarCategory.Id;
        Validate();
    }

    private decimal CalculateTotalPay()
    {       
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

    public void ChangeLocationPickUp(string pickUpLocation)
    {
        PickUpLocation = pickUpLocation;
    }
    public void ChangeLocationReturn(string? returnLocation)
    {
        ReturnLocation = returnLocation;
    }

    public void Validate()
    {
        AssertionConcern.AssertArgumentNotNull(CarCategory, "Car Category Is Null");
        AssertionConcern.AssertArgumentNotNull(PickUpLocation, "PickUp Location Is Null");
    }
}
