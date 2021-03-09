using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppFITSTIC.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public DateTime Inserimento { get; set; }

        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Materia { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher Docente { get; set; }

        public Course() { }

        public Course(string nome, string descrizione, string materia, DateTime inizio, DateTime fine/*, List<Student> studenti*/) 
        {
            Nome = nome;
            Descrizione = descrizione;
            Materia = materia;
            Inizio = inizio;
            Fine = fine;
            Inserimento = DateTime.Now;
            //Studenti = studenti;

            if (string.IsNullOrEmpty(Nome))
                throw new ArgumentNullException("Nome");

            if (string.IsNullOrEmpty(Descrizione))
                throw new ArgumentNullException("Descrizione");

            if (string.IsNullOrEmpty(Materia))
                throw new ArgumentNullException("Materia");
        }

        public override string ToString()
        {
            const int max = 15;
            if (Descrizione.Length <= max) return Descrizione;
            return Descrizione.Substring(0, max) + "...";
        }
    }
}
