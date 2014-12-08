using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged();
                }
            }

        }

        private String nachname;
        public String Nachname
        {
            get { return nachname; }
            set
            {
                if (nachname != value)
                {
                    nachname = value;
                    RaisePropertyChanged();
                }
            }

        }

        private String vorname;
        public String Vorname
        {
            get { return vorname; }
            set
            {
                if (vorname != value)
                {
                    vorname = value;
                    RaisePropertyChanged();
                }
            }

        }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set
            {
                if (geburtsdatum != value)
                {
                    geburtsdatum = value;
                    RaisePropertyChanged();
                }
            }

        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Vorname ist nicht gesetzt.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public string FullName{

            get {
                return Vorname + " " + Nachname;
            }
        }
        

        public override object Clone()
        {
            return new KundeDto
            {
                Id = Id,
                Nachname = Nachname,
                Vorname = Vorname,
                Geburtsdatum = Geburtsdatum
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}",
                Id,
                Nachname,
                Vorname,
                Geburtsdatum);
        }
        public override bool Equals(object obj)
        {
            KundeDto kunde = obj as KundeDto;
            if (kunde != null)
                return this.Id == kunde.Id;

            return false;
        }

    }
}
