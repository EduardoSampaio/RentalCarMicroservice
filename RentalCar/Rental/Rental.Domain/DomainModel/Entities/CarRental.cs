using Rental.Domain.Core;
using Rental.Domain.Core.Interfaces;
using Rental.Domain.DomainModel.ValueObjects;

namespace Rental.Domain.DomainModel.Entities;
public class CarRental : Entity, IAggregateRoot
{
    public DateStartEnd DateStartEnd { get; private set; }
    public decimal TotalPay { get; private set; }
    public bool IsSamePlace { get; private set; }
    public string PickUpLocation { get; set; } = string.Empty;
    public string? ReturnLocation { get; set; }
    public int CarCategoryId { get; private set; }
    public Category CarCategory { get; private set; }
    public Client Client { get; private set; }

    public CarRental(DateTime startDate, DateTime endDate, string pickUpLocation, string? returnLocation, Client client, Category carCategory)
    {
        DateStartEnd = new DateStartEnd(startDate, endDate);
        PickUpLocation = pickUpLocation;
        ReturnLocation = returnLocation;
        TotalPay = CalculateTotalPay();
        CarCategory = carCategory;
        CarCategoryId = CarCategory.Id;
        Client = client;
        Validate();
    }

    public CarRental(DateTime startDate, DateTime endDate, string pickUpLocation, bool isSamePlace, Client client, Category carCategory)
    {
        DateStartEnd = new DateStartEnd(startDate, endDate);
        PickUpLocation = pickUpLocation;
        IsSamePlace = isSamePlace;
        TotalPay = CalculateTotalPay();
        CarCategory = carCategory;
        CarCategoryId = CarCategory.Id;
        Client = client;
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
        AssertionConcern.AssertArgumentNotNull(Client, "Car Category Is Null");
        AssertionConcern.AssertArgumentNotNull(CarCategory, "Car Category Is Null");
        AssertionConcern.AssertArgumentNotNull(PickUpLocation, "PickUp Location Is Null");
    }
}
