using Infrastructure.Controller;
using Infrastructure.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity.Validation;

namespace Infrastructure.Repositorio
{
    public class CEPRepositorio
    {
        public void Salvar(Infrastructure.Entidades.CEP cep)
        {
            using (var ctx = new ControllersContext())
            {
                ctx.Cep.Add(cep);
                ctx.SaveChanges();

            }

        }


        public CEP Buscar(string cep)
        {
            CEP ret = new CEP();
            using (var ctx = new ControllersContext())
            {
                ret = ctx.Cep.Where(x => x.cep == cep).FirstOrDefault();
            }
            return ret;
        }

        public List<CEP> BuscarUf(string uf)
        {
            List<CEP> ceps = new List<CEP>();
            using (var ctx = new ControllersContext())
            {
                ceps = ctx.Cep.Where(x => x.uf == uf).ToList();
            }
            return ceps;
        }

        public List<CEP> Listar()
        {
            using (var ctx = new ControllersContext())
            {
                var CEPs = (from x in ctx.Cep select x).OrderBy(x => x.cep).ToList();
                return CEPs;
            }

        }

        public void Deletar(int id)
        {
            using (var ctx = new ControllersContext())
            {
                CEP cli = ctx.Cep.Find(id);
                ctx.Cep.Remove(cli);
                ctx.SaveChanges();
            }
        }

        public void Editar(CEP cliNovo)
        {
            using (var ctx = new ControllersContext())
            {
                CEP cliAntigo = ctx.Cep.Find(cliNovo.Id);
                //cliAntigo.Nome = cliNovo.Nome;
                //cliAntigo.Email = cliNovo.Email;
                //cliAntigo.Cidade = cliNovo.Cidade;
                ctx.SaveChanges();
            }
        }
    }
}
