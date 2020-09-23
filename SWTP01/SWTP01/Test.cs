using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTP01
{
    public class Test
    {
        

        public Test()
        {
            Console.WriteLine("---Teste---");
            this.readBookCsv();
            this.createAuthor();
            this.viewAuthors();
            this.createBook();
            this.viewBooks();

            Console.WriteLine("---Fim do Teste---");
        }

        public void readBookCsv()
        {
            try
            {
                Repositorio repo = new Repositorio();
                var Books = repo.buscaRep();
                Console.WriteLine("* readBookCsv - SUCCESS");
            }
            catch (IOException e)
            {
                Console.WriteLine("* readBookCsv - FAILED");
                Console.WriteLine(e);
                throw;
            }            

        }

        public void createAuthor()
        {
            try
            {
                Author minhaVida = new Author();
                minhaVida.Name = "MC Gorilla";
                minhaVida.Email = "robson@gmail.com";
                minhaVida.Gender = 'M';

                Console.WriteLine("* createAuthor - SUCCESS");
            }
            catch (IOException e)
            {
                Console.WriteLine("* createAuthor - FAILED");
                Console.WriteLine(e);
                throw;
            }
        }

        public void createBook()
        {           
            try
            {
                Author minhaVida = new Author();
                minhaVida.Name = "Lucas Marques de Oliveira Santos";
                minhaVida.Email = "teste@gmail.com";
                minhaVida.Gender = 'M';

                Author[] autores = { minhaVida };

                Book book1 = new Book("ADS671", autores, 0.00);

                Book book2 = new Book("QUERO CAFÉÉÉÉÉÉÉÉÉÉÉ", autores, 20.00, 5);

                Console.WriteLine("* createBook - SUCCESS");
            }
            catch (IOException e)
            {
                Console.WriteLine("* createBook - FAILED");
                Console.WriteLine(e);
                throw;
            }
        }

        public void viewBooks()
        {
            try
            {
                Console.WriteLine("* viewBooks - SUCCESS /n /n /n /n");

                Repositorio repo = new Repositorio();
                var Books = repo.buscaRep();

                Console.WriteLine("  * createBook - DATA(start)");

                foreach (var book in Books)
                {                   
                    Console.WriteLine($"   book ToString ");
                    Console.WriteLine(book.ToString());
                    Console.WriteLine($"   getAuthorNames | {book.getAuthorNames()}");
                }

                Console.WriteLine("  * createBook - DATA(end)");

                
            }
            catch (IOException e)
            {
                Console.WriteLine("* viewBooks - FAILED");
                Console.WriteLine(e);
                throw;
            }
        }

        public void viewAuthors()
        {
            
            try
            {
                Author author = new Author();
                author.Name = "Uerriton José Eloy da Silva";
                author.Email = "teste@outlook.com.br";
                author.Gender = 'M';

                Author[] autores = { author };

                Console.WriteLine($"* viewAuthors - SUCCESS ({author.Name}, { author.Email}, {author.Gender})");              
            }
            catch (IOException e)
            {
                Console.WriteLine("* viewAuthors - FAILED");
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
