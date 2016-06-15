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
    public class Manzana:Fruta, iSerializable
    {     
        /*Atributo*/
        public double precio;
        private string _rutaArchivo;

        /*Propiedades*/
        public override bool TieneCarozo
        {
            get { return true; }
        }

        public string Tipo
        {
            get { return "Manzana"; }
        }

        /*Constructor*/
        public Manzana()
        { }

        public Manzana(float Peso, ConsoleColor Color, double Precio):base(Peso, Color)
        {
            this.precio = Precio;
        }

        /*Metodos*/
        protected string FrutaToString()
        {
            return string.Concat(base.FrutaToString(), " - Precio: " + this.precio, " - Tiene Carozo: " + this.TieneCarozo, " - Tipo: " + this.Tipo);
        }

        public string ToString()
        {
            return FrutaToString();
        }

        /*Implementacion de iSerializable*/
        public string RutaArchivo
        {
            get
            {
                return this._rutaArchivo;
            }
            set
            {
                this._rutaArchivo = value;
            }
        }

        public bool SerializarXML()
        {
            bool rta = false;

            try
            {
                using (XmlTextWriter Guardar = new XmlTextWriter(this._rutaArchivo, Encoding.UTF8))
                {
                    XmlSerializer Serializador = new XmlSerializer(typeof(Manzana));
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
