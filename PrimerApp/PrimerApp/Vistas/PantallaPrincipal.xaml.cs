using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimerApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantallaPrincipal : ContentPage
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }
        private void BtnCalculadoraSimple_click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CalculadoraSimple());
        }
    }
}