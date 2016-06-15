using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroDeParcial2016
{
    class Platano:Fruta
    {
        /*Atributo*/
        public double precio;

        /*Propiedades*/
        public override bool TieneCarozo
        {
            get { return false; }
        }

        public string Tipo
        {
            get { return "Platano"; }
        }

        /*Constructor*/
        public Platano(float Peso, ConsoleColor Color, double Precio):base(Peso, Color)
        {
            this.precio = Precio;
        }

        /*Metodos*/
        protected string FrutaToString()
        {
            return string.Concat(base.FrutaToString(), " - Precio: " + this.precio, " - Tiene carozo: " + this.TieneCarozo, " - Tipo: " + this.Tipo); 
        }

        public string ToString()
        {
            return FrutaToString();
        }
    }
}
