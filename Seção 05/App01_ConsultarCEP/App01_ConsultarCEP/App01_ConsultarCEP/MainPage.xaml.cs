using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCep;
		}


        private void BuscarCep(object sender, EventArgs args)
        {
            activity.IsVisible = true;
            activity.IsRunning = true;
            activity.Color = Color.Black;

            string cep = CEP.Text.Trim();


            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (endereco == null)
                    {
                        throw new Exception(string.Format("O endereço não foi encontrado para o CEP informado ({0})", cep));
                    }

                    RESULTADO.Text = endereco.ToString();

                    activity.IsVisible = false;
                    activity.IsRunning = false;
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }


        private bool IsValidCEP(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caractéres", "OK");

                return false;
            }

            if (!int.TryParse(cep, out int novoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto apenas por números", "OK");

                return false;
            }

            return true;
        }
	}
}
