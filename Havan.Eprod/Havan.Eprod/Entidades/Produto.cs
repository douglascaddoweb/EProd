using Havan.Eprod.Enum;

namespace Havan.Eprod.Entidades
{
    public class Produto
    {
        public int Id { get; private set; }

        public int CategoriaId { get; private set; }

        public string  Nome { get; private set; }

        public int QtdEstoque { get; private set; }

        public int QtdEstoqueMinimo { get; private set; }

        public decimal Valor { get; private set; }

        public decimal ValorPromocao { get; private set; }

        public EnumSituacao Situacao { get; private set; }

        public virtual Categoria Categoria { get; private set; }

        public Produto(int id, string nome, int qtdEstoque, int qtdEstoqueMinimo, decimal valor, decimal valorPromocao, EnumSituacao situacao)
        {
            Id = id;
            Nome = nome;
            QtdEstoque = qtdEstoque;
            QtdEstoqueMinimo = qtdEstoqueMinimo;
            Valor = valor;
            ValorPromocao = valorPromocao;
            Situacao = situacao;
        }

        public string ValidarEstoque()
        {
            if (QtdEstoque <= QtdEstoqueMinimo)
                return "Estoque abaixo do mínimo aceito.";

            return string.Empty;
        }

        public void AtivarProduto() => Situacao = EnumSituacao.Ativo;

        public void InativarProduto() => Situacao = EnumSituacao.Inativo;


    }
}
