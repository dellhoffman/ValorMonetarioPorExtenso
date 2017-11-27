using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorMonetario
{
    public class ValorMonetario
    {
        private static string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
        private static string[] dezenasEspeciais = { "", "onze", "doze", "treze", "quatorze", "quinze", "desesseis", "desesete", "dezoito", "dezenove" };
        private static string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sesseta", "setenta", "oitenta", "noventa" };
        private static string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        private static string MensagemValorInvalido = "Valor inválido! Apenas números positivos de até três dígitos";

        public static string Converte(string valor)
        {
            decimal valorConvert;
            if (!decimal.TryParse(valor, out valorConvert)) { throw new Exception(MensagemValorInvalido); }

            return Converte(valorConvert);
        }

        public static string Converte(decimal valor)
        {
            valor = Arredondamentos(valor);
            ValidarValor(valor);

            if (valor == 0)
            {
                return ("zero");
            }
            if (valor == 1)
            {
                return ("Um real");
            }
            if (valor == 100)
            {
                return "Cem reais";
            }
            int inteiro = GetNumeroInteiro(valor);
            int fracao = GetNumeroFracionadoComoInteiro(valor);

            string valorExtensoInteiro = getExtension(inteiro);
            string valorExtensoFracao = getExtension(fracao);
            if (fracao > 0)
            {
                string centavos = fracao == 1 ? " centavo" : " centavos";
                valorExtensoFracao += centavos;
                valorExtensoFracao = inteiro > 0 ? " e " + valorExtensoFracao : valorExtensoFracao;
            }
            else
            {
                valorExtensoFracao = string.Empty;
            }
            string valorPorExntenso = inteiro > 0 ? valorExtensoInteiro + " reais" + valorExtensoFracao : valorExtensoFracao;

            return valorPorExntenso;
        }

        private static decimal Arredondamentos(decimal valor)
        {
            return decimal.Round(valor, 2);
        }

        /// <summary>
        /// Deve permitir apenas valores inteiros e de até 3 unidades
        /// </summary>
        /// <param name="valor"></param>
        private static void ValidarValor(decimal valor)
        {
            if (valor > 999.99m || valor < 0)
            {
                throw new Exception(MensagemValorInvalido);
            }
        }

        private static int GetNumeroFracionadoComoInteiro(decimal valor)
        {
            int inteiro = GetNumeroInteiro(valor);
            decimal fracao = (valor - inteiro);

            string onlyFracao = fracao.ToString().Remove(0, fracao.ToString().IndexOf(",") + 1);

            return Convert.ToInt32(onlyFracao);
        }

        private static int GetNumeroInteiro(decimal valor)
        {
            return (int)Math.Abs(valor);
        }

        private static string getExtension(int inteiro)
        {
            string extensoCentena = "";
            string extensoDezena = "";
            string extensoUnidade = "";
            string vlrS = inteiro.ToString();
            int tam = vlrS.Length;
            if (tam > 3)
            {
                return ("Valor Inválido!");
            }
            vlrS = CompleteZeros(vlrS, tam);
            int unidade = getUnidade(vlrS);
            int dezena = getDezena(vlrS);
            int centena = getCentena(vlrS);
            if (centena > 0)
            {
                extensoCentena = centenas[centena] + " e ";
            }
            if (dezena == 1 && unidade > 0)
            {
                extensoDezena = dezenasEspeciais[unidade];
                return extensoCentena + extensoDezena;
            }
            else
            {
                if (unidade > 0)
                {
                    extensoUnidade = (dezena > 0 || centena > 0) ? " e " + unidades[unidade] : unidades[unidade];
                }
                extensoDezena = dezenas[dezena];
            }
            return extensoCentena + extensoDezena + extensoUnidade;
        }


        private static int getUnidade(string valor)
        {
            string unidade = valor.Substring(2, 1);

            return Convert.ToInt32(unidade);
        }

        private static int getDezena(string valor)
        {
            string dezena = valor.Substring(1, 1);

            return Convert.ToInt32(dezena);
        }

        private static int getCentena(string valor)
        {
            string centena = valor.Substring(0, 1);

            return Convert.ToInt32(centena);
        }

        private static string CompleteZeros(string vlrS, int tam)
        {
            for (int i = 0; i < 3 - tam; i++)
            {
                vlrS = "0" + vlrS;
            }
            return vlrS;
        }
    }
}
