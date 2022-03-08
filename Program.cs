
using Dio.Series.Classes;
using Dio.Series.Interface;


class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    listaSerie();
                    break;
                case "2":
                    InsereSerie();
                    break;
                case "3":
                   // AtualizaSerie();
                    break;
                case "4":
                   // AtualizaSerie();
                    break;
                case "5":
                   // AtualizaSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                 throw new ArgumentOutOfRangeException();
            }
        }
    }

    private static void listaSerie()
    {
        System.Console.WriteLine("Listar series");

        var lista = repositorio.Lista();
        
        if (lista.Count == 0)
        {
            System.Console.WriteLine("Nenhuma serie encontrada");
            return;
        }

        foreach (var serie in lista)
        {
            System.Console.WriteLine($"#ID {serie.retornaId()} - {serie.retornaTitulo()}");
        }
    }
    private static void InsereSerie()
    {
        System.Console.WriteLine("Inserir nova serie.");

        foreach (var i in Enum.GetValues(typeof(Genero)))
        {
            System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }

        System.Console.WriteLine("Digite o genero entre as seires");
        int entraGenero = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o genero entre as seires");
        string entraTitulo = Console.ReadLine();

        System.Console.WriteLine("Digite o genero entre as seires");
        int entraAno = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Digite o genero entre as seires");
        string entraDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entraGenero,
                                    titulo: entraTitulo,
                                    ano: entraAno,
                                    descricao: entraDescricao);
        repositorio.Insere(novaSerie);
    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Dio serie ao seu dispor!!!");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1 - Listar series");
        Console.WriteLine("2 - Inserir nova serie");
        Console.WriteLine("3 - Atualizar serie");
        Console.WriteLine("4 - Excluir serie");
        Console.WriteLine("5 - Visualizar serie");
        Console.WriteLine("C - Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        System.Console.WriteLine();
        return opcaoUsuario;
    }
}