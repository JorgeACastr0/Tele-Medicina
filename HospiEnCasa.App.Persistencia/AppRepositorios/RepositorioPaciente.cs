using System;
using System.Linq;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly AppContext _appContext;
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext=appContext;
        }
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado=_appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado= _appContext.Pacientes.FirstOrDefault(p =>p.Id==idPaciente.ToString());//p es el primero que encuentra. Recorre todos los elementos de la tabla
            if(pacienteEncontrado==null)
            return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();//Se deben guardar los cambios
        }   
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }

        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p =>p.Id==idPaciente.ToString());//retorna lo que encuentra
        }

        Paciente IRepositorioPaciente.UpdatePaciente  (Paciente paciente)
        {
            var pacienteEncontrado= _appContext.Pacientes.FirstOrDefault(p =>p.Id==paciente.Id);
            if(pacienteEncontrado!=null)
            {
                pacienteEncontrado.Nombre1=paciente.Nombre1;
                pacienteEncontrado.Nombre2=paciente.Nombre2;
                pacienteEncontrado.Apellido1=paciente.Apellido1;
                pacienteEncontrado.Apellido2=paciente.Apellido2;
                pacienteEncontrado.EmailPte=paciente.EmailPte;
                pacienteEncontrado.TelefonoPte=paciente.TelefonoPte;
                pacienteEncontrado.Genero=paciente.Genero;   
                pacienteEncontrado.Patologia=paciente.Patologia;
                pacienteEncontrado.FamiliarContacto=paciente.FamiliarContacto;
                pacienteEncontrado.Edad=paciente.Edad;
                pacienteEncontrado.DireccionResidencia=paciente.DireccionResidencia;
                pacienteEncontrado.IdResponsable=paciente.IdResponsable;             
                pacienteEncontrado.HistoriaClinica=paciente.HistoriaClinica;
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }
    }
}