using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public abstract class Vehiculo
    {
        public DateTime ingreso;
        private  string patente;

        public  string Patente 
        {
            get
            {
                if (Validar(patente) == true)
                {
                    return patente;
                }
                else
                {
                    return "PATENTE INVALIDA";
                }
            }

              set { patente = value; } 

            }


        public virtual string ConsultarDatos()
        {
            return "";
        }

        public  override bool Equals(object obj)
        {
            if (obj is Vehiculo v)
            {
                return string.Equals(Patente, v.Patente);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Patente.GetHashCode();
        }
        public virtual string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ToString()}");
            sb.AppendLine($"Fecha y Hora de Ingreso: {ingreso}");
            return sb.ToString();
        }
        public static bool operator==(Vehiculo v1, Vehiculo v2)
        {
            if (v1.Patente == v2.Patente)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        public override string ToString()
        {
            return $"patente:{Patente}";
        }



        public Vehiculo(string patente)
        {
            ingreso = DateTime.Now.AddHours(-3);   
        }




        public static bool Validar(string patente)
        {
            if (patente == null || (patente.Length != 7 && patente.Length != 9))
            {
                return false;
            }
            if (patente.Length == 7)
            {
                return ValidarPatenteVieja(patente);
            }
            else
            {
                return ValidarPatenteNueva(patente);
            }

        }

        private static bool ValidarPatenteNueva(string patente)
        {
            var array = patente.Split(' ');
            var parteAlfa1 = array[0];
            var parteNum = array[1];
            var parteAlfa2 = array[2];
            return ValidarParteAlfa(parteAlfa1)
                && ValidarParteNum(parteNum)
                && ValidarParteAlfa(parteAlfa2);

        }

        private static bool ValidarPatenteVieja(string patente)//AAA NNN
        {
            var array = patente.Split(' ');
            var parteAlfa = array[0];
            var parteNum = array[1];
            return ValidarParteAlfa(parteAlfa) && ValidarParteNum(parteNum);
        }
        private static bool ValidarParteAlfa(string parteAlfa)
        {
            foreach (var item in parteAlfa)
            {
                if (!char.IsLetter(item))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool ValidarParteNum(string parteNum)
        {
            foreach (var item in parteNum)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }


        public static string GetTipo(string patente)
        {
            if (patente == null)
            {
                return "Patente no ingresada";
            }

            else if (patente.Length == 7)
            {
                return "Patente Vieja";
            }
            else if (patente.Length == 9)
            {
                return "Patente Nueva";
            }
            else
            {
                return "Formato no válido";
            }

        }
    }
}
