using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {
            //converto a string em array int multidimensional
            int[][] ret = ConverteStringEmArrayIntMulti(dadosTriangulo);
            //faço o calculo dos valore máximo de cada linha com a regra de pegar as 2 posições a partir da anterior
            return CalculaMaximoTriangulo(ret);
        }

        private int[][] ConverteStringEmArrayIntMulti(string dadosTriangulo)
        {
            dadosTriangulo = dadosTriangulo.Replace("[[", "").Replace("]]", "");
            var arrayMultString = dadosTriangulo.Split(new string[] { "],[" }, StringSplitOptions.None).Select(x => x.Split(',')).ToArray();

            int[][] arrayMultInt = new int[arrayMultString.Length][];
            for (int j = 0; j < arrayMultString.GetLength(0); j++)
            {
                arrayMultInt[j] = new int[arrayMultString[j].Length];
                for (int i = 0; i < arrayMultString[j].Length; i++)
                {
                    int valor;
                    bool ok = int.TryParse(arrayMultString[j][i], out valor);
                    if (ok)
                        arrayMultInt[j][i] = valor;
                    else
                        arrayMultInt[j][i] = 0;
                }
            }
            return arrayMultInt;
        }

        private int CalculaMaximoTriangulo(int[][] ret)
        {
            int numeroFinal = 0;
            for (int i = 0; i < ret.Length; i++)
            {
                int pos1 = i - 1;
                int pos2 = i;
                if (i == 0)
                    numeroFinal = ret[i][0];
                else
                {
                    if (ret[i][pos1] > ret[i][pos2])
                        numeroFinal = numeroFinal + ret[i][pos1];
                    else
                        numeroFinal = numeroFinal + ret[i][pos2];
                }
            }

            return numeroFinal;
        }
    }
}
