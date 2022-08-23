using System;

namespace TicketMetro.App.Dominio
{

    public class Ticket
    {
        public int ID { get; set; }
        public Persona objPerosna { get; set; }
        public Estacion objEstacionInicial { get; set; }
        public Estacion objEstacionFinal { get; set; }
        public int precion { get; set; }
        public DateTime fecha { get; set; }
    }

}