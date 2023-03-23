using PersonalBookcase;

List<Book> bookcase = new List<Book>();
List<Book> lendBook = new List<Book>();
List<Book> withdrawBook = new List<Book>();

if (File.Exists("EstanteDeLivros.txt"))
{
    bookcase = ReadFile("EstanteDeLivros.txt");
}

if (File.Exists("LivrosEmprestados.txt"))
{
    lendBook = ReadFile("LivrosEmprestados.txt");
}

if (File.Exists("LivrosSendoLidos.txt"))
{
    withdrawBook = ReadFile("LivrosSendoLidos.txt");
}

do
{
    int op = Menu();
    switch (op)
    {
        case 1:
            Book book = CreateBook();
            bookcase.Add(book);
            bookcase = bookcase.OrderBy(x => x.Title).ToList();

            WriteFile(bookcase, "EstanteDeLivros.txt");
            Console.Clear();
            break;

        case 2:
            var withdrawArchive = FindBook(bookcase);
            withdrawBook.Add(withdrawArchive);
            bookcase.Remove(withdrawArchive);
            WriteFile(bookcase, "EstanteDeLivros.txt");
            WriteFile(withdrawBook, "LivrosSendoLidos.txt");
            Console.Clear();
            break;

        case 3:
            Console.Clear();
            var exchangeArchive = FindBook(bookcase);
            lendBook.Add(exchangeArchive);
            bookcase.Remove(exchangeArchive);
            WriteFile(bookcase, "EstanteDeLivros.txt");
            WriteFile(lendBook, "LivrosEmprestados.txt");

            break;

        case 4:
            PrintBookcase(bookcase);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 5:
            PrintBookcase(lendBook);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 6:
            PrintBookcase(withdrawBook);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 7:
            bookcase.Remove(FindBook(bookcase));
            WriteFile(bookcase, "EstanteDeLivros.txt");
            Console.Clear();
            break;

        case 8:
            var refundArchive = FindBook(lendBook);
            bookcase.Add(refundArchive);
            lendBook.Remove(refundArchive);
            WriteFile(bookcase, "EstanteDeLivros.txt");
            WriteFile(lendBook, "LivrosEmprestados.txt");
            Console.Clear();
            break;

        case 9:
            var readArchive = FindBook(withdrawBook);
            bookcase.Add(readArchive);
            withdrawBook.Remove(readArchive);
            WriteFile(bookcase, "EstanteDeLivros.txt");
            WriteFile(withdrawBook, "LivrosSendoLidos.txt");

            Console.Clear();
            break;

        case 10:
            bookcase.Add(EditBook(FindBook(bookcase)));
            WriteFile(bookcase, "EstanteDeLivros.txt");
            Console.Clear();
            break;

        case 11:
            System.Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção inválida");
            Console.Clear();

            break;
    }

} while (true);







//==========================================================================================================================================
Book EditBook(Book book)
{
    Console.WriteLine("Digite a descrição do livro: ");
    book.Description = Console.ReadLine();
    Console.WriteLine("Digite a editora do livro: ");
    book.Publisher = Console.ReadLine();
    EditAuthor(book.Author);
    return book;
}

void EditAuthor(Author author)
{
    Console.WriteLine("Digite a descrição do autor: ");
    author.About = Console.ReadLine();
    Console.WriteLine("Digite o rodapé do livro: ");
    author.Footer = Console.ReadLine();
}

void WriteFile(List<Book> bookcase, string archiveName)
{
    try
    {
        StreamWriter sw = new(archiveName);
        foreach (Book book in bookcase)
        {
            sw.WriteLine(book.ToString());
        }
        sw.Close();
    }
    catch (Exception e)
    {
        throw;
    }
    finally
    {
        Console.WriteLine("Arquivo gravado");
        Thread.Sleep(1000);
    }
}

List<Book> ReadFile(string archiveName)
{
    StreamReader sr = new StreamReader(archiveName);
    List<Book> bookcase = new List<Book>();

    try
    {
        string line;
        string[] aux = new string[9];
        while ((line = sr.ReadLine()) != null)
        {
            aux = line.Split("|");

            Book book = new(int.Parse(aux[0]), aux[1], aux[2], aux[3], aux[8]);
            Author author = new(aux[4], int.Parse(aux[5]), aux[6], aux[7]);

            book.Author = author;
            bookcase.Add(book);


        }
        bookcase = bookcase.OrderBy(x => x.Title).ToList();
        sr.Close();
        Console.WriteLine("Arquivo lido");
        return bookcase;
    }
    catch (Exception e)
    {

        throw;
    }
    return null;
}

Book FindBook(List<Book> bookcase)
{
    Console.WriteLine("Digite o ID do livro: ");
    var id = IsInt();
    foreach (var item in bookcase)
    {
        if (item.Id == (id))
        {
            return item;
        }
    }
    return null;
}

void PrintBookcase(List<Book> bookcase)
{
    foreach (var book in bookcase)
    {
        Console.WriteLine(book.ToString());
    }
}

int Menu()
{
    Console.Clear();
    Console.WriteLine(">>>Menu de opções<<<\n\n1 - Adiciona Livro\n2 - Retirar livro para ler\n" +
        "3 - Emprestar Livro\n4 - Mostrar estante\n5 - Mostrar emprestados\n6 - Mostrar livros na fila" +
        " de leitura\n7 - Remover livro\n8 - Devolver livro emprestado\n9 - Livro terminado\n10 - Editar livro\n11 - Sair\n\n" +
        "Escolha uma opção: ");

    var aux = int.Parse(Console.ReadLine());

    return aux;

}

Book CreateBook()
{
    Console.WriteLine("Digite o ID do livro: ");
    int id = IsInt();

    Console.WriteLine("Digite o título do livro: ");
    string title = Console.ReadLine();

    Console.WriteLine("Digite o ISNB do livro: ");
    string isnb = Console.ReadLine();

    Book book = new(id, title, isnb);

    Console.WriteLine("Quantos autores tem o livro? ");

    int nAuthors = IsInt();
    for (int i = 0; i < nAuthors; i++)
    {
        Console.WriteLine("Digite o nome do autor: ");
        string name = Console.ReadLine();

        Console.WriteLine("Digite o ano de nascimento do autor: ");
        int year = IsInt();

        Author author = new(name, year);

        book.Author = author;
    }



    if (title == "" | isnb == "")
    {
        Console.Clear();
        return CreateBook();
    }
    return book;
}

int IsInt()
{
    int value;
    do
    {
        if (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Digite um número inteiro");
        }
        else
        {
            return value;
        }

    } while (true);
}