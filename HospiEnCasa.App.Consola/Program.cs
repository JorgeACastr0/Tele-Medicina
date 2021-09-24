using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    
    //private static IRepositorioPaciente _repoPaciente=new RepositorioPaciente(new Persistencia.AppContext());
    class Program
    {

        private static IRepositorioPaciente _repoPaciente=new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddPaciente();
            BuscarPaciente(1);
        }

        private static void AddPaciente()
        {
            var paciente=new Paciente
            {
                Nombre1="Jorge",
                Nombre2="Luis",
                Apellido1="Montañez",
                Apellido2="Bogota",
                Genero=Genero.Masculino,
                DireccionResidencia="Calle 1 #1-1",
                EmailPte="jorluis2020@gmail.com",
                TelefonoPte="3012347040",
                Patologia="Sano",
                FamiliarContacto="N/A",
                Edad=20,
                IdResponsable="01",
                HistoriaClinica="123456"
            };
             _repoPaciente.AddPaciente(paciente);
        }
        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine("Nombre: "+paciente.Nombre1+" "+paciente.Apellido1+"  Género: "+paciente.Genero);
        } 
    }
}
