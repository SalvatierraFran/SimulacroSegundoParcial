using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SimulacroDeParcial2016
{
    public class Cajon:iSerializable
    {
        /*Atributos*/
        private int _capacidad;
        private List<Fruta> _frutas;
        private string _rutaArchivo2;

        /*Propiedades*/
        public List<Fruta> Frutas
        {
            get { return this._frutas; }
        }

        public double PrecioDeManzanas
        {
            get { return this.ObtenerTotal(EtipoFruta.Manzana); }
        }

        public double PrecioDePlatanos
        {
            get { return this.ObtenerTotal(EtipoFruta.Platano); }
        }

        public double PrecioTotal
        {
            get { return this.ObtenerTotal(EtipoFruta.Todo); }
        }

        /*Constructores*/
        public Cajon()
        {
            this._frutas = new List<Fruta>(this._capacidad);
        }

        public Cajon(int Capacidad):this()
        {
            this._capacidad = Capacidad;
        }

        /*Metodos*/
        private double ObtenerTotal(EtipoFruta Tipo)
        {
            double retorno = 0;

            if (Tipo == EtipoFruta.Todo)
            {
                for (int i = 0; i < this._frutas.Count; i++)
                {
                    if (this._frutas[i] is Manzana)
                    {
                        retorno += ((Manzana)this._frutas[i]).precio;
                    }
                    else
                    {
                        retorno += ((Platano)this._frutas[i]).precio;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this._frutas.Count; i++)
                {
                    if ((this._frutas[i] is Manzana) && (Tipo == EtipoFruta.Manzana))
                    {
                        retorno += ((Manzana)this._frutas[i]).precio;
                    }

                    if ((this._frutas[i] is Platano) && (Tipo == EtipoFruta.Platano))
                    {
                        retorno += ((Platano)this._frutas[i]).precio;
                    }
                }
            }

            return retorno;
        }

        public string ToString()
        {
            string rta = "";

            foreach (Fruta item in this._frutas)
            {
                if (item is Manzana)
                {
                    string man;
                    man = ((Manzana)item).ToString();
                    Console.WriteLine(man);
                }

                if (item is Platano)
                {
                    string pla;
                    pla = ((Platano)item).ToString();
                    Console.WriteLine(pla);
                }
            }

            rta = string.Concat("\nCapacidad: " + this._capacidad);

            return rta;
        }

        /*Sobrecarga de operador*/
        public static Cajon operator +(Cajon c, Fruta f)
        {
            if (c._capacidad > c._frutas.Count)
                c._frutas.Add(f);

            return c;
        }

        /*Implementacion de iSerializable*/
        public string RutaArchivo
        {
            get
            {
                return this._rutaArchivo2;
            }
            set
            {
                this._rutaArchivo2 = value;
            }
        }

        public bool SerializarXML()
        {
            bool rta = false;

            try
            {
                using (XmlTextWriter Guardar = new XmlTextWriter(this._rutaArchivo2, Encoding.UTF8))
                {
                    XmlSerializer Serializador = new XmlSerializer(typeof(Cajon));
                    Serializador.Serialize(Guardar, this);
                    rta = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rta;
        }
    }
}
