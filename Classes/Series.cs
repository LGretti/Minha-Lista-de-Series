using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seriess
{
    public class Series : EntidadeBase /*Heranca*/
    {
        // Atributos
        private Generos Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set;} // Melhor forma de "excluir" informacoes


        // Metodos e Construtores
        public Series(int id, Generos genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string msg = "";
            msg += "Gênero: " + this.Genero + Environment.NewLine;
            msg += "Título: " + this.Titulo + Environment.NewLine;
            msg += "Descrição: " + this.Descricao + Environment.NewLine;
            msg += "Ano de Início: " + this.Ano + Environment.NewLine;
            msg += "Excluido: " + this.Excluido;
            return msg;
        }

        // Encapsulamento
        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

    }
}