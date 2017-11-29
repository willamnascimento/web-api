using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Data.context;
using WebApi.Data.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        public Hashtable Add()
        {
            var retorno = new Hashtable();
            var _params = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            var email = _params["email"];
            var apelido = _params["apelido"];
            var nome = _params["nome"];
            var senha = _params["senha"];
            var carga_horaria = _params["carga_horaria"];

            if (IsValid(email))
            {
                using (var db = new context())
                {
                    var account = new account
                    {
                        apelido = apelido,
                        ativo = true,
                        data_cadastro = DateTime.Now,
                        email = email,
                        nome = nome,
                        resetar_senha = false,
                        senha = senha,
                        ultimo_acesso = DateTime.Now,
                        carga_horaria = TimeSpan.Parse(carga_horaria)
                    };
                    db.accounts.Add(account);
                    db.SaveChanges();
                    retorno.Add("message", "Incluido com sucesso.");
                }
            }
            else
            {
                retorno.Add("message", "E-mail ja existente.");
            }
            return retorno;
        }

        public Hashtable Login()
        {
            var retorno = new Hashtable();
            var _params = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            var email = _params["email"];
            var senha = _params["senha"];

            using (var db = new context())
            {
                if (db.accounts.Any(x => x.email == email && x.senha == senha))
                    retorno.Add("message", "Usuário logado com sucesso.");
                else
                    retorno.Add("message", "Usuário não encontrado.");
            }
            return retorno;
        }

        private bool IsValid(string email)
        {
            using (var db = new context())
            {
                if (db.accounts.Any(x => x.email == email))
                    return false;
                return true;
            }
        }
    }
}
