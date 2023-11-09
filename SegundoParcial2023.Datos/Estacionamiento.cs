using SegundoParcial2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Datos
{
    public class Estacionamiento
    {
        private int EspacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculo;

        public Estacionamiento(int espacioDisponible, string nombre):this()
        {
            EspacioDisponible = espacioDisponible;
            this.nombre = nombre;
        }

        private Estacionamiento()
        {
            vehiculo = new List<Vehiculo>();
        }

         public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Espacios Disponibles:{e.EspacioDisponible }");
            sb.AppendLine($"Nombre:{e.nombre}");

            foreach (var v in e.vehiculo)
            {
                sb.AppendLine(v.ToString());
                
            }

            return sb.ToString();

        }

        public List<Vehiculo> GetVehiculos()
        {
            return vehiculo;
        }

        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {

            foreach (var item in e.vehiculo)
            {
                if (item.Patente == v.Patente)
                {
                    return true;
                }
            }
            return false;


        }
        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }
        public static bool operator +(Estacionamiento e, Vehiculo v)
        {

            if (e != v && e.EspacioDisponible > e.vehiculo.Count() && v.Patente != "")
            {
                e.vehiculo.Add(v);
                return true;
            }
            return false;

    }
    public static string operator -(Estacionamiento e, Vehiculo v)
        {
            if (e == v)
            {
                e.vehiculo.Remove(v);

                return v.ImprimirTicket();
            }
            return "El vehiculo no es parte del estacionamiento";

        }


    }
}
