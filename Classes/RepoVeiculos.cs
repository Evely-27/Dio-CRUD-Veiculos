using System;
using System.Collections.Generic;
using DIO.Veiculos;
using DIO.Veiculos.Interfaces; 

namespace DIO.Veiculos
{
	public class VeiculoRepo : IRepo<Veiculo>
	{
        private List<Veiculo> listaVeiculo = new List<Veiculo>();
		public void Atualiza(int id, Veiculo objeto)
		{
			listaVeiculo[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaVeiculo[id].Excluir();
		}

		public void Insere(Veiculo objeto)
		{
			listaVeiculo.Add(objeto);
		}

		public List<Veiculo> Lista()
		{
			return listaVeiculo;
		}

		public int ProximoId()
		{
			return listaVeiculo.Count;
		}

		public Veiculo RetornaPorId(int id)
		{
			return listaVeiculo[id];
		}
	}
}