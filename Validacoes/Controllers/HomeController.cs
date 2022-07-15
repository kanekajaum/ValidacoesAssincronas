using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validacoes.Models;

namespace Validacoes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Validacao(string str)
        {
            var UnidadeGestora = new List<UnidadeGestora>() {
                new UnidadeGestora(){ Id = 1, Nome="110101"},
                new UnidadeGestora(){ Id = 2, Nome="90003"},
                new UnidadeGestora(){ Id = 3, Nome="270901"},
                new UnidadeGestora(){ Id = 4, Nome="30001"},
                new UnidadeGestora(){ Id = 5, Nome="550901"}
            };

            var Fonte = new List<Fonte>() {
                new Fonte(){ Id = 1, Nome="440"},
                new Fonte(){ Id = 2, Nome="100"},
                new Fonte(){ Id = 3, Nome="520"},
                new Fonte(){ Id = 4, Nome="250"},
                new Fonte(){ Id = 5, Nome="305"}
            };

            var Credor = new List<Credor>() {
                new Credor(){ Id = 1, Nome="9462685"},
                new Credor(){ Id = 2, Nome="4157577"},
                new Credor(){ Id = 3, Nome="8245819"},
                new Credor(){ Id = 4, Nome="7157862"},
                new Credor(){ Id = 5, Nome="3988847"}
            };

            var CPF = new List<CPF>() {
                new CPF(){ Id = 1, Nome="50371667054"},
                new CPF(){ Id = 2, Nome="63157706063"},
                new CPF(){ Id = 3, Nome="76411523088"},
                new CPF(){ Id = 4, Nome="42173970038"},
                new CPF(){ Id = 5, Nome="14391635020"}
            };
            var respostaUG = "";

            if (str != "")
            {
                var UGs = UnidadeGestora.Where(x => x.Nome.Contains(str)).Take(3);
                respostaUG = String.Join(", ", UGs.Select(x => x.Nome).ToList());
                if (UGs.Count() < 1) 
                {
                    respostaUG = "Sem Registros";
                }
            }
            else
            {
                respostaUG = "Sem Registros";
            }

            return Json(respostaUG, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ValidacaoCampos(string unidadeGestora, string fonte, string credor, string cpf)
        {
            var respostaUG = validarUG(unidadeGestora);
            var respostaFonte = validarFonte(fonte);
            var respostaCredor = validarCredor(credor);
            var respostaCPF = validarCPF(cpf);

            List<string> data = new List<string>();

            data.Add(respostaUG);
            data.Add(respostaFonte);
            data.Add(respostaCredor);
            data.Add(respostaCPF);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public string validarUG(string unidadeGestora) 
        {
            var UnidadeGestora = new List<UnidadeGestora>() {
                new UnidadeGestora(){ Id = 1, Nome="110101"},
                new UnidadeGestora(){ Id = 2, Nome="90003"},
                new UnidadeGestora(){ Id = 3, Nome="270901"},
                new UnidadeGestora(){ Id = 4, Nome="30001"},
                new UnidadeGestora(){ Id = 5, Nome="550901"}
            };

            var respostaUG = "";

            if (unidadeGestora != "")
            {
                var UGs = UnidadeGestora.Where(x => x.Nome.Contains(unidadeGestora)).Take(3);
                respostaUG = String.Join(", ", UGs.Select(x => x.Nome).ToList());
                if (UGs.Count() < 1)
                {
                    respostaUG = "Sem Registros";
                }
                return respostaUG;
            }
            else
            {
                return "Sem Registros";

            }
        }

        public string validarFonte(string fonte)
        {
            var Fonte = new List<Fonte>() {
                new Fonte(){ Id = 1, Nome="440"},
                new Fonte(){ Id = 2, Nome="100"},
                new Fonte(){ Id = 3, Nome="520"},
                new Fonte(){ Id = 4, Nome="250"},
                new Fonte(){ Id = 5, Nome="305"}
            };

            var respostaFonte = "";

            if (fonte != "")
            {
                var Fontes = Fonte.Where(x => x.Nome.Contains(fonte)).Take(3);
                respostaFonte = String.Join(", ", Fontes.Select(x => x.Nome).ToList());
                if (Fontes.Count() < 1)
                {
                    respostaFonte = "Sem Registros";
                }
                return respostaFonte;
            }
            else
            {
                return "Sem Registros";

            }
        }

        public string validarCredor(string credor)
        {
            var Credor = new List<Credor>() {
                new Credor(){ Id = 1, Nome="9462685"},
                new Credor(){ Id = 2, Nome="4157577"},
                new Credor(){ Id = 3, Nome="8245819"},
                new Credor(){ Id = 4, Nome="7157862"},
                new Credor(){ Id = 5, Nome="3988847"}
            };

            var respostaCredor = "";

            if (credor != "")
            {
                var Credores = Credor.Where(x => x.Nome.Contains(credor)).Take(3);
                respostaCredor = String.Join(", ", Credores.Select(x => x.Nome).ToList());
                if (Credores.Count() < 1)
                {
                    respostaCredor = "Sem Registros";
                }
                return respostaCredor;
            }
            else
            {
                return "Sem Registros";
            }
        }

        public string validarCPF(string cpf)
        {
            var CPF = new List<CPF>() {
                new CPF(){ Id = 1, Nome="50371667054"},
                new CPF(){ Id = 2, Nome="63157706063"},
                new CPF(){ Id = 3, Nome="76411523088"},
                new CPF(){ Id = 4, Nome="42173970038"},
                new CPF(){ Id = 5, Nome="14391635020"}
            };

            var respostaCPF = "";

            if (cpf != "")
            {
                var CPFs = CPF.Where(x => x.Nome.Contains(cpf)).Take(3);
                respostaCPF = String.Join(", ", CPFs.Select(x => x.Nome).ToList());
                if (CPFs.Count() < 1)
                {
                    respostaCPF = "Sem Registros";
                }
                return respostaCPF;
            }
            else
            {
                return "Sem Registros";
            }
        }

        [HttpPost]
        public ActionResult Criar(string unidadeGestora, string fonte, string credor, string cpf) 
        {
            return Content(unidadeGestora);
        }
    }
}