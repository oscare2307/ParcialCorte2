namespace Parcial2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        double CalcularPago(double principal, double TasaInteres, int Años)
        {
            // Validar entrada
            ValidarEntrada(principal, TasaInteres, Años);

            // Calcular la tasa de interés mensual
            double TasaMensual = TasaInteres / 100 / 12;

            // Calcular el número de pagos
            int PagosTotales = Años * 12;

            // Aplicar la fórmula de pago del préstamo
            return (principal * TasaMensual) / (1 - Math.Pow(1 + TasaMensual, -PagosTotales));
        }

        void ValidarEntrada(double principal, double TasaInteres, int Años)
        {
            if (principal < 1000000)
            {
                throw new ArgumentException("El monto del préstamo debe ser mínimo de $1.000.000");
            }
            if (TasaInteres > 33.09)
            {
                throw new ArgumentException("La tasa de interés excede la tasa de usura(33.09%)");
            }
            if (Años * 12 < 6)
            {
                throw new ArgumentException("El plazo mínimo debe ser de 6 meses");
            }
        }


        private void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            

            {
                try
                {
                    double principal = double.Parse(EntryPrestamo.Text);
                    double TasaInteres = double.Parse(EntryTasa.Text);
                    int Años = int.Parse(EntryPeriodo.Text);

                    double mensualidad = CalcularPago(principal, TasaInteres, Años);
                    EntryPago.Text = $"Pago mensual: ${mensualidad:0.00}";
                }
                catch (FormatException ex)
                {
                    DisplayAlert("Error de formato", "Ingrese valores numéricos válidos para monto, tasa e interés", "Aceptar");
                }
                catch (ArgumentException ex)
                {
                    DisplayAlert("Validación de datos", ex.Message, "Aceptar");
                }
            }

        }

        private void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            EntryPrestamo.Text = "";
            EntryTasa.Text = "";
            EntryPeriodo.Text = "";
            EntryPago.Text = "";
            EntryPrestamo.Focus();
        }
    }

}
