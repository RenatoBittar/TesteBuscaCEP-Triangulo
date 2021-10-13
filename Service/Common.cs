using Infrastructure.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Common
    {
        public async Task<CEP> BuscaeCEPViaApi(string cep)
        {
            CEP cepRetorno = null;
            string path = "https://viacep.com.br/ws/" + cep + "/json/";
            //TODO: Resolver dados com caracter especial no retorno do JSON 
            HttpClient client = new HttpClient();
            //result = client.DownloadString(viaCEPUrl);
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var retorno = await response.Content.ReadAsStringAsync();
                cepRetorno = JsonConvert.DeserializeObject<CEP>(retorno);
            }

            return cepRetorno;
        }
        public bool ValidarCep(string cep)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
        }

        public bool ValidarUF(string uf)
        {
            List<string> listaUF = new List<string>();
            listaUF.AddRange(new string[] {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "GO", "ES", "MA",
    "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN",
    "RS", "RO", "RR", "SP", "SC", "SE", "TO"});

            return listaUF.Contains(uf.ToUpper());

        }
    }
}
