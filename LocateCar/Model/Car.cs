namespace LocateCar.Model {
    public class Car {

        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public bool IsAvailable { get; set; } = true;

        public Car() {
        }

        public Car(string placa, string marca) {
            Placa = placa;
            Marca = marca;
        }

    }
}