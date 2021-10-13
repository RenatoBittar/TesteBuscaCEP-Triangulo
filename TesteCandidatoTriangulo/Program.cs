using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {


            int[][] ret = ConvertArrayMulti("[[6],[3,5],[9,7,1],[4,6,8,4]]");
            //--26

            int retorno = CalculaMaximoTriangulo(ret);

            var r = "";

        }

        private static int CalculaMaximoTriangulo(int[][] ret)
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

        private static int[][] ConvertArrayMulti(string args)
        {
            args = args.Replace("[[", "").Replace("]]", "");
            var arrayMultString = args.Split(new string[] { "],[" }, StringSplitOptions.None).Select(x => x.Split(',')).ToArray();

            int[][] arrayMultInt = new int[arrayMultString.Length][];
            for (int j = 0; j < arrayMultString.GetLength(0); j++)
            {
                arrayMultInt[j] = new int[arrayMultString[j].Length];
                for (int i = 0; i < arrayMultString[j].Length; i++)
                {
                    int valor;
                    bool ok = int.TryParse(arrayMultString[j][i], out valor);
                    if (ok)
                    {
                        arrayMultInt[j][i] = valor;
                    }
                    else
                    {
                        arrayMultInt[j][i] = 0;
                    }
                }
            }
            return arrayMultInt;
        }
    }
}
