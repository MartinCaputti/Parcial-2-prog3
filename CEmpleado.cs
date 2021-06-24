using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    abstract class CEmpleado:IComparable
    {
        private string DNI;
        private string apellido;
        private string nombre;


        public CEmpleado(string DNI, string apellido ,string nombre)
        {
            this.DNI = DNI;
            this.apellido = apellido;
            this.nombre = nombre;
        }

        public virtual string darDatos()
        {
            return "\nDNI: " + this.DNI + " Apellido: " + this.apellido + " Nombre: " + this.nombre; 
        }

        public string getDni()
        {
            return this.DNI;
        }

        //Pongo el compareTo para poder ordernarlos por DNI luego ; 
        public int CompareTo(object obj)
        {

            //Version compare con strings 
            /* if (obj is CEmpleado)
             {
                return this.DNI.CompareTo(((CEmpleado)obj).getDni());
             }
            */

            /*
            Los pase a int porque con strings me quedaba alfabeticamente  y salian primero los numeros que comenzaban con 1 , despues con 2 ,etc
            ej : 1 , 10 , 150 ,2 , 21 , 3 .... 
            Con numeros lo pude solucionar y muestra el orden real             
             */
            int dni1, dni2;
            if (obj is CEmpleado)
            {
                dni1 = int.Parse( this.DNI);
                dni2 = int.Parse( ((CEmpleado)obj).getDni());

                return dni1 - dni2;
            }



            else return int.MaxValue;
        }
    }



}
