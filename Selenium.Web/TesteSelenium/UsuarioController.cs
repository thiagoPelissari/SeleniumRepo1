using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSelenium
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public string Post()
        {
            string nome = Request.Form["nome"];
            string sobrenome = Request.Form["Sobrenome"];
            string sexo = Request.Form["sexo"];
            string telefone = Request.Form["Telefone"];
            string cpf = Request.Form["CPF"];
            string cep = Request.Form["CEP"];
            string endereco = Request.Form["Endereco"];
            string cidade = Request.Form["Cidade"];
            string cargo = Request.Form["Cargo"];
            string nomeMae = Request.Form["nomeMae"];

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf))
                return "Erro, Nome e Cpf obrigatórios";
           
            string registro = $"{nome};{sobrenome};{sexo};{telefone};{cpf};{cep};{endereco};{cidade};" +
                $"{cargo};{nomeMae}";

            string targetFile = Path.Combine("C:\\TestePrj", "ListaUsuario.txt");

            using (var tw = new StreamWriter(targetFile, true))
            {
                tw.WriteLine(registro);
            }

            return "Sucesso";

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
