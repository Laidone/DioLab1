using System;

namespace DioLab1
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcao();
            
            while (opcaoUsuario.ToUpper() != "x"){
                if (opcaoUsuario.Equals("1")) {
                    ListarSeries();
					break;
                }
                else if(opcaoUsuario.Equals("2")){
                    InserirSerie();
					break;
                }
				else if (opcaoUsuario.Equals("3")){
					AtualizarSerie();
					break;
				}
				else if (opcaoUsuario.Equals("4")){
					ExcluirSerie();
					break;
				}
				else if (opcaoUsuario.Equals("5")){
					VisualizarSerie();
					break;
				}
				else if (opcaoUsuario.Equals("C")){
					Console.Clear();
					break;
				}
				else{
					throw new ArgumentOutOfRangeException();
				}
            }
        }

         private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite o tipo de mídia (DVD, Bluray ou streaming");
            string m_Midia = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAno, midia: m_Midia);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o tipo de mídia da Série: ");
            string m_Midia = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno,	descricao: entradaDescricao, midia: m_Midia);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcao(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("Digite 1 para listar as séries");
            Console.WriteLine("Digite 2 para inserir uma nova série");
            Console.WriteLine("Digite 3 para Atualizar série");
            Console.WriteLine("Digite 4 para excluir série");
            Console.WriteLine("Digite 5 para visualizar série");
            Console.WriteLine("Digite C para limpar tela");
            Console.WriteLine("Digite X para sair");
        
            String opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
