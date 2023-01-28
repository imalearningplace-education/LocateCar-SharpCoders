
using LocateCar.Service.Interfaces;

namespace LocateCar.Service.TaxServices;
public class EUATaxService : ITaxService {

    public double Tax(double amount) {
      return 0.12 * amount;
    }

}
