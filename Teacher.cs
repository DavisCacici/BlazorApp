using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorAppFITSTIC.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public DateTime Inserimento { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime Data_Nascita { get; set; }
        public string Materia { get; set; }
        public List<Course> Corsi { get; set; } = new List<Course>();

        public Teacher() { }

        public Teacher(string nome, string cognome, DateTime nascita, string materia)
        {
            Nome = nome;
            Cognome = cognome;
            Data_Nascita = nascita;
            Materia = materia;
            Inserimento = DateTime.Now;

            if (string.IsNullOrEmpty(Nome))
                throw new ArgumentNullException("Nome");

            if (string.IsNullOrEmpty(Cognome))
                throw new ArgumentNullException("Cognome");
        }
    }
}
