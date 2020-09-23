using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    class Program
    {
        static void Main(string[] args)
        {

            new Test();
            //Console.ReadKey();

            IWebHost host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();
            host.Run();

           
        }

        public class Startup
        {

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddRouting();
            }

            public void Configure(IApplicationBuilder app)
            {
               
                var builder = new RouteBuilder(app);
                builder.MapRoute("/nomeDoLivro", NameBook);
                builder.MapRoute("/resultadoToString", resultadoToString);
                builder.MapRoute("/getAuthorNames", getAuthorNames);               
                builder.MapRoute("/livro/ApresentarLivro/{id:int}", showDetails);
                var rotas = builder.Build();
                app.UseRouter(rotas);


            }

            public Task showDetails(HttpContext context)
            {
                int id = Convert.ToInt32(context.GetRouteValue("id"));
                Repositorio repo = new Repositorio();
                var livro = repo.buscaRep();
                var fileContent = loadHtmlFile("HTML");
                var htmlBody = "";

                htmlBody = $" <h2>Nome</h2> <p>{livro[id].Name}</p>" +
                           $"<ul><li> Autores <ul><li>{livro[id].getAuthorNames()}</li></ul></li></ul>" +
                           $"<h4>E-mail</h4> <p>{livro[id].Email}</p>" +
                           $"<h4>Preço</h4> <p>{livro[id].Price}</p>" +
                           $"<h4>Quantidade</h4> <p>{livro[id].Quantidade}</p>";



                fileContent = fileContent.Replace("#NOVO-ITEM", $"{htmlBody} #NOVO-ITEM");

                fileContent = fileContent.Replace("#NOVO-ITEM#", "");
                return context.Response.WriteAsync(fileContent);

            }


            public Task NameBook(HttpContext context)
            {
                Repositorio repo = new Repositorio();
                var livros = repo.buscaRep();
                string lista = "Nome dos Livros: \n";
                foreach (var livro in livros)
                {
                    lista = String.Concat(lista, "\n", livro.Name);
                }
                return context.Response.WriteAsync(lista);
            }
            public Task resultadoToString(HttpContext context)
            {
                Repositorio repo = new Repositorio();
                var livros = repo.buscaRep();
                string lista = "";
                foreach (var livro in livros)
                {
                    lista = String.Concat(lista, "\n" ,livro.ToString());
                }

                return context.Response.WriteAsync(lista);
            }

            public Task getAuthorNames(HttpContext context)
            {
                Repositorio repo = new Repositorio();
                var livros = repo.buscaRep();

                string lista = "";
                foreach (var livro in livros)
                {
                    lista = String.Concat(lista, "\n", livro.getAuthorNames());
                }

                return context.Response.WriteAsync(lista);
            }

            private string loadHtmlFile(string fileName)
            {
                var completeName = $"HTML/{fileName}.html";
                using(var file = File.OpenText(completeName))
                {
                    return file.ReadToEnd();
                }
            }
        }

    }
}
