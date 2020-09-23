using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    class Repositorio
    {
        private static readonly string nomeArquivoCSV = "C:\\SWTP01\\SWTP01\\SWTP01\\livros.csv";


        public Repositorio()
        {

        }


        public List<Book> buscaRep()
        {
            using (var file = File.OpenText(Repositorio.nomeArquivoCSV))
            {
                var books = new List<Book>();

                while (!file.EndOfStream)
                {
                    Author[] autores = new Author[2];
                    var textoLivro = file.ReadLine();

                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }

                    var infoLivro = textoLivro.Split(';');


                    var autor1 = new Author();
                    autor1.Name = infoLivro[4];
                    autores.SetValue(autor1, 0);

                    if (infoLivro.Length == 6)
                    {
                        var autor2 = new Author();
                        autor2.Name = infoLivro[5];
                        autores.SetValue(autor2, 1);
                    }

                    
                    var livro = new Book(infoLivro[0], autores, double.Parse(infoLivro[2]), int.Parse(infoLivro[3]));

                    livro.Email = infoLivro[1];

                    books.Add(livro);

                }

                return books;

            }
        }

       

    }
}
