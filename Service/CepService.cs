using Infrastructure.Entidades;
using Infrastructure.Repositorio;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Service
{
    public class CepService
    {

        private readonly CEPRepositorio _cepRepositorio;
        private readonly Common common;

        public CepService(CEPRepositorio cepRepositorio)
        {
            _cepRepositorio = cepRepositorio;
            common = new Common();

    }

        public void Salvar(CEP cep)
        {
            _cepRepositorio.Salvar(cep);

        }

        public List<CEP> BuscarUf(string uf)
        {
            
            if (common.ValidarUF(uf))
                return _cepRepositorio.BuscarUf(uf);
            else
                throw new Exception("UF Inválido");
        }

      

        public CEP Buscar(string valor)
        {
            CEP cep = null;
            //removo - caso tenha 
            valor = valor.Replace("-", "");
            if (valor.Length == 8)
                valor = valor.Substring(0, 5) + "-" + valor.Substring(5, 3);
            if (common.ValidarCep(valor))
            {
                cep = _cepRepositorio.Buscar(valor);
                if (cep == null)
                {
                    //busca o cep na api externa 
                    cep = common.BuscaeCEPViaApi(valor).Result;
                    //salva no bd
                    _cepRepositorio.Salvar(cep);
                }
            }
            else
                throw new Exception("Cep Inválido");
            return cep;
        }

        

       

        public List<CEP> Listar()
        {
            return _cepRepositorio.Listar();
        }

        public void Delete(int id)
        {
            _cepRepositorio.Deletar(id);

        }

        public void Editar(CEP cliNovo)
        {
            _cepRepositorio.Editar(cliNovo);
        }

    }
}
