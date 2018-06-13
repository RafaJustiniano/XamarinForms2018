using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";




        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null)
            {
                return null;
            }

            return endereco;
        }
    }
}
