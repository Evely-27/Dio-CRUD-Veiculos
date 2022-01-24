using System;

namespace DIO.Veiculos
{
    class Program
    {
        static VeiculoRepo repositorio = new VeiculoRepo();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarVeiculos();
						break;
					case "2":
						InserirVeiculo();
						break;
					case "3":
						AtualizarVeiculo();
						break;
					case "4":
						ExcluirVeiculo();
						break;
					case "5":
						VisualizarVeiculo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirVeiculo()
		{
			Console.Write("Digite o id da série: ");
			int indiceVeiculos = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceVeiculos);
		}

        private static void VisualizarVeiculo()
		{
			Console.Write("Digite o id do veículo: ");
			int indiceVeiculos = int.Parse(Console.ReadLine());

			var veiculo = repositorio.RetornaPorId(indiceVeiculos);

			Console.WriteLine(veiculo);
		}

        private static void AtualizarVeiculo()
		{
			Console.Write("Digite o id do veículo: ");
			int indiceVeiculo = int.Parse(Console.ReadLine());
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo do veículo: ");
			string entradaVeiculo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do veículo: ");
			string entradaDescricao = Console.ReadLine();

			Veiculo AtualizarVeiculo = new Veiculo(id: indiceVeiculo,
										marca: (Marca)entradaMarca,
										modelo: entradaVeiculo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceVeiculo, AtualizarVeiculo);
		}
         private static void ListarVeiculos()
		 {
		 	Console.WriteLine("Listar veículos.");

		 	var lista = repositorio.Lista();

		 	if (lista.Count == 0)
		 	{
		 		Console.WriteLine("Nenhum veículo  cadastrado.");
		 		return;
		 	}

		 	foreach (var veiculo in lista)
		 	{
                 var excluido = veiculo.retornaExcluido();
                
		 		Console.WriteLine("#ID {0}: - {1} {2}", veiculo.retornaId(), veiculo.retornaModelo(), (excluido ? "*Excluído*" : ""));
		 	}
		}

        private static void InserirVeiculo()
		{
			Console.WriteLine("Inserir novo veículo:");

			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo do Veículo: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Ano de Laçamento: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do veículo: ");
			string entradaDescricao = Console.ReadLine();

			Veiculo novoVeiculo = new Veiculo(id: repositorio.ProximoId(),
										marca: (Marca)entradaMarca,
										modelo: entradaModelo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoVeiculo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Registre seus veículos!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Veículos.");
			Console.WriteLine("2- Inserir Novo Veículo");
			Console.WriteLine("3- Atualizar Veículo");
			Console.WriteLine("4- Excluir Veículo");
			Console.WriteLine("5- Visualizar Veículo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}