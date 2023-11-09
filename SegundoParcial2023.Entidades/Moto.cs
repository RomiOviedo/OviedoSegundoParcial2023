using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private short ruedas=2;
        private int valorHora;


        public override string ConsultarDatos()
        {
            return $"{cilindrada}, {ruedas}, {valorHora}, {GetType().Name}";
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ImprimirTicket()
        {
            return base.ImprimirTicket();
        }




        public Moto(string patente) : base(patente)
        {
            ingreso = DateTime.Today.AddHours(30);
        }


        public Moto(string patente,int cilindrada, short ruedas):this(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = ruedas;
        }

        public Moto(string patente, int cilindrada, short ruedas, int valorHora):this(patente, cilindrada, ruedas)
        {
            this.valorHora = valorHora;
        }

        public Moto()
        {
        }
    }
}
