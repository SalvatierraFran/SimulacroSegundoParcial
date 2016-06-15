using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroDeParcial2016
{
    public abstract class Fruta
    {
        /*Atributos*/
        protected ConsoleColor _color;
        protected float _peso;

        /*Propiedades*/
        public abstract bool TieneCarozo
        {
            get;
        }

        /*Constructor*/
        public Fruta()
        { }
        
        public Fruta(float Peso, ConsoleColor Color)
        {
            this._peso = Peso;
            this._color = Color;
        }

        /*Métodos*/
        protected virtual string FrutaToString()
        {
            string rta = "";

            rta = string.Concat("Color: " + this._color, " - Peso: " + this._peso);

            return rta;
        }

        public static int OrdenarPorPesoAsc(Fruta f1, Fruta f2)
        {
            return f1._peso.CompareTo(f2._peso);
        }

        public static int OrdenarPorPesoDesc(Fruta f1, Fruta f2)
        {
            return f2._peso.CompareTo(f1._peso);
        }
    }
}
