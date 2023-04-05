namespace ExeComInterfaces.Services
{
    // SERVIÇO DE IMPOSTO DO BRASIL
    class BrazilTaxService : ITaxService // OBSERVAÇÃO: Não é herança, é realização de Interface. SUPERTIPO
    {
        public double Tax(double amount) // Assinatura igual da Interface ITaxService
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}