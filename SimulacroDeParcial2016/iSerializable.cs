using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroDeParcial2016
{
    interface iSerializable
    {
        /*Propiedad*/
        string RutaArchivo
        {
            get;
            set;
        }

        /*Metodo*/
        bool SerializarXML();
    }
}
