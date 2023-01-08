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

    public partial class CalculadoraSimple : ContentPage
    {
        public CalculadoraSimple()
        {
            InitializeComponent();
        }


        public double x = 0, y = 0, resultado = 0;
        int operador = 0; //El puso 4 acá
        bool contienePunto = false, unoDecimal = false, dosDecimal = false;
        private void Igualar(String operando, int valor)
        {
            bool validateType = lblNumero.Text.GetType() != operador.GetType();
            bool validateSpan = spnFirst.Text.GetType() != operando.GetType();
            if (resultado != 0 || ((validateType || validateSpan) || (validateSpan && validateType)))
                unoDecimal = true;
            if (unoDecimal)
                x = double.Parse(lblNumero.Text);
            else
                x = int.Parse(lblNumero.Text);
            spnFirst.Text = x + " ";
            lblNumero.Text = "0";
            spnSecond.Text = operando;
            operador = valor;
            contienePunto = false;
        }

        private bool Lleno()
        {
            bool estaLleno = false;
            if (spnFirst.Text == "" && spnSecond.Text == "")
            {
                estaLleno = true;
            }                
            return estaLleno;
        }

        private void IngresarNumero(String numero)
        {
            if (lblNumero.Text == "0" && numero != ",")
            {
                lblNumero.Text = numero;
            }                
            else
            {
                lblNumero.Text += numero;
            }                
        }

        private void BtnAC(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            resultado = 0;
            contienePunto = false;
            spnFirst.Text = "";
            spnSecond.Text = "";
            spnThird.Text = "";
            lblNumero.Text = "0";
        }



        private void BtnC (object sender, EventArgs e)
        {
            if (lblNumero.Text.EndsWith(","))
            {
                contienePunto = false;
            }
            if (lblNumero.Text != "0" && lblNumero.Text != "0.")
            {
                if (double.Parse(lblNumero.Text) > 0)
                {
                    lblNumero.Text = lblNumero.Text.Substring(0, lblNumero.Text.Length - 1);
                }                    
                else
                {
                    lblNumero.Text = "0";
                }                    
            }
            if (lblNumero.Text.EndsWith(","))
            {
                lblNumero.Text = lblNumero.Text.Substring(0, lblNumero.Text.Length - 1);
            }
        }

        private void BtnSumar(object sender, EventArgs e)
        {
            Igualar("+", 0);
            if (!Lleno())
            {
                spnThird.Text = "";
            }
        }

        private void BtnRestar (object sender, EventArgs e)
        {
            Igualar("-", 1);
            if (!Lleno())
            {
                spnThird.Text = "";
            }
        }

        private void BtnMultiplicar (object sender, EventArgs e)
        {
            Igualar("*", 2);
            if (!Lleno())
            {
                spnThird.Text = "";
            }
        }

        private void BtnDividir(object sender, EventArgs e)
        {
            Igualar("/", 3);
            if (!Lleno())
            {
                spnThird.Text = "";
            }
        }

        private void BtnCero (object sender, EventArgs e)
        {
            if (lblNumero.Text != "0")
            {
                IngresarNumero("0");
            }
        }


        private void BtnUno(object sender, EventArgs e)
        {
            IngresarNumero("1");
        }
        private void BtnDos(object sender, EventArgs e)
        {
            IngresarNumero("2");
        }
        private void BtnTres(object sender, EventArgs e)
        {
            IngresarNumero("3");
        }
        private void BtnCuatro(object sender, EventArgs e)
        {
            IngresarNumero("4");
        }
        private void BtnCinco(object sender, EventArgs e)
        {
            IngresarNumero("5");
        }
        private void BtnSeis(object sender, EventArgs e)
        {
            IngresarNumero("6");
        }
        private void BtnSiete(object sender, EventArgs e)
        {
            IngresarNumero("7");
        }
        private void BtnOcho(object sender, EventArgs e)
        {
            IngresarNumero("8");
        }
        private void BtnNueve(object sender, EventArgs e)
        {
            IngresarNumero("9");
        }
        private void Regresar (object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void BtnPunto(object sender, EventArgs e)
        {
            if (!contienePunto)
            {
                IngresarNumero(",");
                contienePunto = true;
            }
            if (operador == 4)
            {
                unoDecimal = true;
            }
            else
            {
                dosDecimal = true;
            }
        }

        private void BtnIgual(object sender, EventArgs e)
        {
            if (spnFirst.Text!="" && spnSecond.Text != "")
            {
                spnThird.Text = " " + lblNumero.Text;
                if (dosDecimal)
                {
                    y= double.Parse(spnThird.Text);
                }
                else
                {
                    y=int.Parse(spnThird.Text);
                }
                if (operador == 0)
                {
                    resultado = x + y;
                    lblNumero.Text = resultado + "";
                }else if (operador == 1)
                {
                    resultado = x - y;
                    lblNumero.Text = resultado + "";
                }
                else if (operador == 2)
                {
                    resultado = x * y;
                    lblNumero.Text = resultado + "";
                }
                else
                {
                    if (y == 0)
                    {
                        y = 1;
                    }
                    resultado = x / y;
                    lblNumero.Text = resultado + "";
                }
                x = 0;
                y = 0;
                resultado = 0;
                operador = 4;
                unoDecimal = false;
                dosDecimal = false;
            }
        }

    }
}