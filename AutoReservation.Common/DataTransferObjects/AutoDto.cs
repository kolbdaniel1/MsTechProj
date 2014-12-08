using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase
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

        private string marke;
        public string Marke
        {
            get { return marke; }
            set
            {
                if (marke != value)
                {
                    marke = value;
                    RaisePropertyChanged();
                }
            }
        }

        private AutoKlasse autoKlasse;
        public AutoKlasse AutoKlasse
        {
            get { return autoKlasse; }
            set
            {
                if (autoKlasse != value)
                {
                    autoKlasse = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int tagesTarif;
        public int Tagestarif
        {
            get { return tagesTarif; }
            set
            {
                if (tagesTarif != value)
                {
                    tagesTarif = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int basisTarif;
        public int Basistarif
        {
            get { return basisTarif; }
            set
            {
                if (basisTarif != value)
                {
                    basisTarif = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (tagesTarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && basisTarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasse = AutoKlasse,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasse);
        }

        public override bool Equals(object obj)
        {
            AutoDto auto = obj as AutoDto;
            if(auto != null)
                return this.Id == auto.Id;

            return false;
        }

    }
}
