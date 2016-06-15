using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroDeParcial2016
{
    class Program
    {
        static void Main(string[] args)
        {
            Manzana ManzanaUno = new Manzana(15f, ConsoleColor.Red, 2.99f);
            Manzana ManzanaDos = new Manzana(20f, ConsoleColor.Green, 3.15f);
            Manzana ManzanaTres = new Manzana(18f, ConsoleColor.Red, 3.25f);

            Platano PlatanoUno = new Platano(10f, ConsoleColor.Yellow, 5.99f);
            Platano PlatanoDos = new Platano(8f, ConsoleColor.Yellow, 4.50f);
            Platano PlatanoTres = new Platano(15f, ConsoleColor.Yellow, 7.99f);

            Cajon MiCajon = new Cajon(5);

            MiCajon += ManzanaUno;
            MiCajon += ManzanaDos;
            MiCajon += ManzanaTres;

            MiCajon += PlatanoUno;
            MiCajon += PlatanoDos;
            MiCajon += PlatanoTres;

            MiCajon.ToString();

            Console.WriteLine("### Ordenamiento por Peso Desc ###");
            MiCajon.Frutas.Sort(Fruta.OrdenarPorPesoDesc);
            MiCajon.ToString();

            Console.WriteLine("### Ordenamiento por Peso Asc ###");
            MiCajon.Frutas.Sort(Fruta.OrdenarPorPesoAsc);
            MiCajon.ToString();

            Console.WriteLine("Precio total de Manzanas: " + MiCajon.PrecioDeManzanas);
            Console.WriteLine("PRecio total de Platanos: " + MiCajon.PrecioDePlatanos);
            Console.WriteLine("Precio total: " + MiCajon.PrecioTotal);

            ManzanaUno.RutaArchivo = "Manzana.Xml";
            bool ser = Serializar(ManzanaUno);
            if (ser == true)
            {
                Console.WriteLine("Serialización de Manzana OK");
            }

            MiCajon.RutaArchivo = "Cajon.Xml";
            bool ser2 = Serializar(MiCajon);
            if (ser2 == true)
            {
                Console.WriteLine("Serializacion de Cajon OK");
            }

            Console.ReadKey();
        }

        static bool Serializar(iSerializable Obj)
        {
            return Obj.SerializarXML();
        }
    }
}
