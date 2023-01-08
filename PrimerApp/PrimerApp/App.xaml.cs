using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrimerApp.Vistas;

namespace PrimerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new PantallaPrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
