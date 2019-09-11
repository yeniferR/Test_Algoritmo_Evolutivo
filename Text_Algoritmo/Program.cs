using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Algoritmo
{
    class Program
    {
        private static Random creaCaracter = new Random();
        private static string mutacion = "TYUQWPJGNMXZSHFDIOQWHBVXCO";
        private static char resulcombinacion;

      
        public static int validarDatos(string valor1)
        {
            string entradacadena = "MVM INGENIERIA DE SOFTWARE";
            var resultcadena = 0;
            var primerdato = valor1;
            var segundodato = entradacadena;
            for (int i = 0; i < primerdato.Length; i++)
            {
                if (primerdato[i] == segundodato[i])
                {
                    resultcadena++;
                }
            }

            return resultcadena;

        }

        public static string CrearCombinacion(int poscombinacion)
        {
            string combinacion = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            int poscimbinacion = combinacion.Length;
            string cadenaGanerada = "";
            int totalcombinacion = 1;
            for (int i = 0; i < totalcombinacion; i++)
            {
                resulcombinacion = combinacion[creaCaracter.Next(poscimbinacion)];
                cadenaGanerada += resulcombinacion.ToString();
            }
            return cadenaGanerada;
        }
        static void Main(string[] args)
        {

            
            var puntajealto = 0;
            var index = 1;
            var acdenamayor = "";
            while (puntajealto < 26)
            {
                for (int x = 0; x < 50; x++)
                {
                    var lista = new List<WeightedItem<string>>();
                    for (int y = 0; y < mutacion.Length; y++)
                    {
                        WeightedItem<string> valoresEntrada = new WeightedItem<string>(y.ToString(), 0.03);
                        lista.Add(valoresEntrada);
                    }
                    var valorElegido = Convert.ToInt32(WeightedItem<string>.Choose(lista));
                    var insertCaracter = CrearCombinacion(1);
                     index += 1;
                    mutacion = mutacion.Remove(valorElegido, 1).Insert(valorElegido, insertCaracter);
                    var resulPuntaje = validarDatos(mutacion);
                    if (puntajealto < resulPuntaje)
                    {
                        puntajealto = resulPuntaje;
                        acdenamayor = mutacion;
                    }
                    Console.WriteLine("Generación:" + index + " - Mutación:" + mutacion + " - Puntaje:" + validarDatos(mutacion));

                }
                mutacion = acdenamayor;
            }
            Console.WriteLine("Generación:" + index + " - Mutación:" + mutacion + " - Puntaje:" + validarDatos(mutacion));
            Console.ReadKey();

        }
    }
}
