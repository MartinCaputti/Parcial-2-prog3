using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class CObrero : CEmpleado
    {
        private especialidad esp;

        public CObrero(string DNI , String apellido ,String nombre ,int espObre):base(DNI,apellido,nombre)
        {
            this.esp = (especialidad) espObre;
        }

        public especialidad getEspecialidad()
        {
            return this.esp;
        }

        public override string darDatos()
        {
            return base.darDatos() + "  Especialidad: " + this.esp.ToString()  ;
        }


    }

    public enum especialidad
    {
        Albañil=1,Pintor,Plomero,Herrero,Eletricista
    };

}
