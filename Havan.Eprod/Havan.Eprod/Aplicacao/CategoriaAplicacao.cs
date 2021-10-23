using Havan.Eprod.Entidades;
using Havan.Eprod.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Havan.Eprod.Aplicacao
{
    public class CategoriaAplicacao
    {
        private List<Categoria> _categoria;

        public CategoriaAplicacao()
        {
            if (_categoria == null) 
                _categoria = new List<Categoria>();
        }

        public int ObterId()
        {
            return _categoria.Count() + 1;
        }

        public void AdicionarCategoria(string nome, byte situacao)
        {
            int id = ObterId();
            _categoria.Add(new Categoria(id, nome, (EnumSituacao)situacao));

            Console.WriteLine("Cadastrado com sucesso");
        }

        public Categoria ObterCategoria(int id) => _categoria.Find(i => i.Id == id);

        public void AtualizarCategoria(int id, string nome, byte situacao)
        {
            Categoria categoria = ObterCategoria(id);

            categoria.Atualizar(nome, (EnumSituacao) situacao);

            Console.WriteLine("Atualizado com sucesso");
        }

        public void RemoverCategoria(int id)
        {
            Categoria categoria = ObterCategoria(id);

            //if (categoria.IsTemProdutos())
            //{
                _categoria.Remove(categoria);
                Console.WriteLine("Removido com sucesso");
            //}
            //else
            //    Console.WriteLine("Não foi possível remover a categoria");
        }

        public void ObterLista()
        {
            foreach (Categoria categoria in _categoria)
                Console.WriteLine(categoria.ToString());
        }
    }
}
