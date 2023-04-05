using ExeComInterfaces.Entities;
using System;

namespace ExeComInterfaces.Services
{
    //SERVIÇO DE ALUGUEL
    class RentalService // serviço responsavel por processar o aluguel e gerar a nota de pagamento (Invoice)
    {
        public double PricePerHour { get; private set; } // protegi com private, ou seja, só posso obtelos e não posso alterar
        public double PricePerDay { get; private set; } // protegi com private, ou seja, só posso obtelos e não posso alterar

        //Antes sem Interface. Era apenas serviço do brasil settado agora posso variar com a Interface
        //private BrazilTaxService _brazilTaxService = new BrazilTaxService();
        //public RentalService(double pricePerHour, double pricePerDay)
        //{
        //    PricePerHour = pricePerHour;
        //    PricePerDay = pricePerDay;
        //}

        private ITaxService _taxService; 

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental) // Vai processar um CarRental(aluguel de carros) e gerar a nota de pagamento dele
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); // Math.Ceiling arredonda pra cima

            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment); // Serviço de imposto _brazilTaxService.Tax calculando o pagemtno basico basicPayment

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
