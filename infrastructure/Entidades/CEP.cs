using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entidades
{
    public class CEP
    {
        public int Id { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public Int64 unidade { get; set; }
        public int ibge { get; set; }
        public string gia { get; set; }
    }
}
