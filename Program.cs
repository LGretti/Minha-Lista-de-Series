using Seriess;
using System;

namespace Seriess {
  class Program
  {
    static SeriesRepositorio repositorio = new SeriesRepositorio();
    static void Main(string[] args)
    {
      string opcUsuario = ObterOpcUsuario();

      while (opcUsuario.ToUpper() != "X")
      {
        switch (opcUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcUsuario = ObterOpcUsuario();
      }
      Console.WriteLine("Obrigado por trabalhar conosco.");
      Console.WriteLine();
    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar Séries");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma Serie Cadastrada.");
        return;
      }

      foreach (var serie in lista) {
        var excluido = serie.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "Excluído" : ""));
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
      foreach (int i in Enum.GetValues(typeof(Generos)))
      {
        Console.WriteLine(" {0}-{1} ", i, Enum.GetName(typeof(Generos), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Series novaSerie = new Series(id: repositorio.ProximoId(),
                                    genero: (Generos) entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

      repositorio.Insere(novaSerie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
      // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
      foreach (int i in Enum.GetValues(typeof(Generos)))
      {
        Console.WriteLine(" {0}-{1} ", i, Enum.GetName(typeof(Generos), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Series atualizaSerie = new Series(id: indiceSerie,
                                        genero: (Generos) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
      Console.Write("Informe o Id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
      Console.Write("Informe o Id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);
    }

    private static string ObterOpcUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Projeto DIO - Lucas Gretti");
      Console.WriteLine("Digite o valor da Opção desejada:");

      Console.WriteLine("------------------------------------");
      Console.WriteLine("1 - Listar Séries");
      Console.WriteLine("2 - Inserir Nova Série");
      Console.WriteLine("3 - Atualizar Serie");
      Console.WriteLine("4 - Excluir Série");
      Console.WriteLine("5 - Visualizar Série");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine("------------------------------------");
      Console.WriteLine();

      string opUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opUsuario;
    }
  }
}