using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValorMonetario.Teste
{
    [TestClass]
    public class ValorMonetarioTeste
    {
        private static string MensagemValorInvalido = "Valor inválido! Apenas números positivos de até três dígitos";

        [TestMethod]
        public void TesteValor_10_reais()
        {
            string valorExtenso = ValorMonetario.Converte(10);
            Assert.AreEqual(valorExtenso, "dez reais");
        }

        [TestMethod]
        public void TesteValor_MenorQueZero()
        {
            try
            {
                string valorExtenso = ValorMonetario.Converte(-5);
            }
            catch (Exception ex)
            {
                AssertFailedException.Equals(MensagemValorInvalido, ex);
            }

        }
        [TestMethod]
        public void TesteValor_MaiorQueTresAlgarismos()
        {
            try
            {
                string valorExtenso = ValorMonetario.Converte(5000);
            }
            catch (Exception ex)
            {
                AssertFailedException.Equals(MensagemValorInvalido, ex);
            }

        }
        [TestMethod]
        public void TesteValor_Fracionado()
        {
            string valorExtenso = ValorMonetario.Converte(22.58m);
            Assert.AreEqual(valorExtenso, "vinte e dois reais e cinquenta e oito centavos");
        }

        [TestMethod]
        public void TesteValor_Maximo()
        {
            string valorExtenso = ValorMonetario.Converte(999.99m);
            Assert.AreEqual(valorExtenso, "novecentos e noventa e nove reais e noventa e nove centavos");
        }
        [TestMethod]
        public void TesteValor_Minimo()
        {
            string valorExtenso = ValorMonetario.Converte(0.01m);
            Assert.AreEqual(valorExtenso, "um centavo");
        }
        [TestMethod]
        public void TesteValor_Arredondamento()
        {
            string valorExtenso = ValorMonetario.Converte(888.98654321m);
            Assert.AreEqual(valorExtenso, "oitocentos e oitenta e oito reais e noventa e nove centavos");
        }

        [TestMethod]
        public void TesteValor_NaoNumero()
        {
            try
            {
                string valorExtenso = ValorMonetario.Converte("asdfasdfsa");
            }
            catch (Exception ex)
            {
                AssertFailedException.Equals(MensagemValorInvalido, ex);
            }
        }

    }

}
