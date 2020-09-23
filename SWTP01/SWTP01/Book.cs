using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    class Book
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public double Price { get; set; }
        public Author[] Authors { get; set; }
        public int Quantidade { get; set; }

        public Book(string name, Author[] authors, double price)
        {
            Name = name;
            Authors = authors;
            Price = price;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            Name = name;
            Authors = authors;
            Price = price;
            Quantidade = qty;
        }


        public override string ToString()
        {

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"     Nome = {Name}");
            stringBuilder.AppendLine($"     Autores");

            foreach (var author in Authors)
            {
                if (author != null)
                {
                stringBuilder.AppendLine($"      Autor {author.Name}, Email {author.Email} , Genero {author.Gender.ToString()}");
                }
            }
            

            stringBuilder.AppendLine($"     Email = {Email}");
            stringBuilder.AppendLine($"     Preco = {Price}");
            stringBuilder.AppendLine($"     Quantidade = {Quantidade}");


            return stringBuilder.ToString();


        }

        public string getAuthorNames()
        {
            string resultado = " ";

            foreach (var author in Authors.Select((value, i) => new { i, value }))
            {
                if (author.value != null)
                {
                    if (author.i == (Authors.Length - 1))
                    {
                        resultado += ", " + author.value.Name;
                    }
                    else
                    {
                        resultado += author.value.Name ;

                    }
                }
                
            }

            return resultado;
        }


    }
}
