using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _02._4.pesquisa
{
    internal class Pesquisa
    {
        private readonly Label txtPesquisa;
        private readonly List<string> parametros;
        private int indiceDe;

        public Pesquisa(Label txtPesquisa, List<string> parametros)
        {
            this.txtPesquisa = txtPesquisa;
            this.parametros = parametros;
        }

        internal string ExecutarComando(string tipoComando)
        {
            if (parametros
                .Where(p => string.IsNullOrWhiteSpace(p))
                .Any())
                return "Os parâmetros precisam ser preenchidos";

            switch (tipoComando)
            {
                case "Contem":
                    return Contem();
                case "ComecaCom":
                    return ComecaCom();
                case "TerminaCom":
                    return TerminaCom();
                case "IndiceDe":
                    return IndiceDe();
                case "UltimoIndiceDe":
                    return UltimoIndiceDe();
                case "Trecho":
                    return Trecho();
                case "Substituir":
                    return Substituir();
                default:
                    return string.Empty;
            }
        }

        private string Contem()
        {
            //txtPesquisa: caixa de texto do Windows Forms
            var textoBusca = parametros.FirstOrDefault() ?? string.Empty;

            bool contem = txtPesquisa.Text.Contains(textoBusca);

            if (contem)
            {
                return "O documento CONTÉM a string '" + textoBusca + "'";
            }
            else
            {
                return "O documento NÃO CONTÉM a string '" + textoBusca + "'";
            }
        }

        private string ComecaCom()
        {
            var textoBusca = parametros.FirstOrDefault() ?? string.Empty;

            bool comecaCom = txtPesquisa.Text.StartsWith(textoBusca);

            if (comecaCom)
            {
                return "O documento COMEÇA COM a string '" + textoBusca + "'";
            }
            else
            {
                return "O documento NÃO COMEÇA COM a string '" + textoBusca + "'";
            }
        }

        private string TerminaCom()
        {
            var textoBusca = parametros.FirstOrDefault() ?? string.Empty;

            var terminaCom = txtPesquisa.Text.EndsWith(textoBusca);

            if (terminaCom)
            {
                return "O documento TERMINA COM a string '" + textoBusca + "'";
            }
            else
            {
                return "O documento NÃO TERMINA COM a string '" + textoBusca + "'";
            }
        }

        private string IndiceDe()
        {
            var textoBusca = parametros.FirstOrDefault() ?? string.Empty;

            indiceDe = txtPesquisa.Text.IndexOf(textoBusca, StringComparison.CurrentCulture);

            if (indiceDe == -1)
            {
                return "String não encontrada: '" + textoBusca + "'";
            }
            else
            {
                return "Índice da string '" + textoBusca + "' é: " + indiceDe;
            }
        }

        private string UltimoIndiceDe()
        {
            var textoBusca = parametros.FirstOrDefault() ?? string.Empty;

            indiceDe = txtPesquisa.Text.LastIndexOf(textoBusca, StringComparison.CurrentCulture);

            if (indiceDe == -1)
            {
                return "String não encontrada: '" + textoBusca + "'";
            }
            else
            {
                return "Último índice da string '" + textoBusca + "' é: " + indiceDe;
            }
        }

        private string Trecho()
        {
            int.TryParse(parametros[0], out int indiceInicial);
            int.TryParse(parametros[1], out int comprimento);

            // txtPesquisa.SelectionStart = indiceInicial;
            // txtPesquisa.SelectionLength = comprimento;

            string trecho = txtPesquisa.Text.Substring(indiceInicial, comprimento);

            return "O trecho selecionado é: " + trecho;
        }

        private string Substituir()
        {
            var antigoTexto = parametros[0];
            var novoTexto = parametros[1];

            txtPesquisa.Text = txtPesquisa.Text.Replace(antigoTexto, novoTexto);

            return "Trecho substituído com sucesso.";
        }
    }
}