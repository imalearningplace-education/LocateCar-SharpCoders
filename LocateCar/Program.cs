using LocateCar.Model;
using LocateCar.Service;
using LocateCar.Service.TaxServices;
using LocateCar.View;

namespace LocateCar;

public class Program {

    public static void Main(string[] args) {

        Pessoa pessoa = PessoaView.MenuNovaPessoa();
        Car carro = new Car("ABC-1234", "Ferrari");
        DateTime start = new DateTime(2023, 01, 25, 10, 00, 00);
        DateTime finish = new DateTime(2023, 01, 27, 22, 30, 00);
        TimeSpan duracao = finish - start;
        Console.WriteLine($"Duração: {duracao.Hours}");
        CarRental aluguel = new CarRental(1L, start, finish, carro, pessoa);

        CarRentalService service = new CarRentalService(150, 15, new BrasilTaxService());
        CarRentalService serviceEUA = new CarRentalService(150, 15, new EUATaxService());

        // 5:30 => 6h => basico: 90 taxa: 13.5 total: 103.5
        // 2d 2:30 => 2d 3h => basico: 345 taxa: ... total: ...

        service.ProcessInvoice(aluguel);
        Console.WriteLine(aluguel);

        Console.WriteLine("----------------");

        serviceEUA.ProcessInvoice(aluguel);
        Console.WriteLine(aluguel);

    }

}