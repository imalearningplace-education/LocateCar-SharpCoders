using LocateCar.Model;
using LocateCar.Service.Interfaces;
using LocateCar.Util;

namespace LocateCar.Service;

public class CarRentalService {

    List<CarRental> rentals;
    public double PricePerDay { get; set; }
    public double PricePerHour { get; set; }

    private ITaxService _taxService;

    public CarRentalService(double pricePerDay, double pricePerHour, ITaxService taxService) {
        new List<CarRental>();
        PricePerDay = pricePerDay;
        PricePerHour = pricePerHour;
        _taxService = taxService;
    }

    public void ProcessInvoice(CarRental carRental) {

        if (carRental.Finish == null)
            return;

        TimeSpan time = (TimeSpan)(carRental.Finish - carRental.Start);
        double basicPayment = 0, tax = 0;
        int days = time.Days, hours = time.Hours;

        if(time.Minutes > 0) {
            hours++;
        }

        if(hours > 12) {
            days++;
            hours = 0;
        }

        basicPayment = PricePerDay * days + PricePerHour * hours;
        tax = _taxService.Tax(basicPayment);
        carRental.Invoice = new Invoice(basicPayment, tax);
    }

}
