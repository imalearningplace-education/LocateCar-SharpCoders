namespace LocateCar.Model {
    public class Invoice {

        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public double TotalPayment {
            get { return BasicPayment + Tax; }
        }

        public Invoice(double basicPayment, double tax) {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public override string ToString() {
            return $"Pag. Base: R${BasicPayment:F2} | Taxa: R${Tax:F2}\n"
                + $"Total Pago: R${TotalPayment:F2}";
        }
    }
}
