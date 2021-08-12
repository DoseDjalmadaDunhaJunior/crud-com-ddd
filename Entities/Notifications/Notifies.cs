using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notitycoes;

        /// <summary>
        /// A função abaixo gera a notificação para o usuario ser obrigado a colocar 
        /// a descrição do produto
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nomePropriedade"></param>
        /// <returns></returns>
        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {

            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }
            return true;
        }

        /// <summary>
        /// a função abaixo gera a notificação pçara o usuario que o campo valor deve ser maior que zero
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nomePropriedade"></param>
        /// <returns></returns>
        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {

            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Valor tem que ser Maior que 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;

        }

        /// <summary>
        /// a função abaixo gera a notificação pçara o usuario que o campo valor deve ser maior que zero
        /// a diferença com o de cima é que esse abrange a parte decimal
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="nomePropriedade"></param>
        /// <returns></returns>

        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {

            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    mensagem = "Tem que ser maior que zero",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;

        }
    }
}
