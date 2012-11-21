using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase
    {
        private int _id;
        private AutoKlasse _autoklasse;
        private string _marke;
        private Nullable<int> _basistarif;
        private int _tagestarif;

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(_marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (_tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && _basistarif <= 0)
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
        [DataMember]
        public Nullable<int> Basistarif
        {
            get { return _basistarif; }
            set
            {
                if (value != _basistarif)
                {
                    SendPropertyChanging(() => Basistarif);
                    _basistarif = value;
                    SendPropertyChanged(() => Basistarif);
                }
            }
        }
        [DataMember]
        public int Tagestarif
        {
            get { return _tagestarif; }
            set
            {
                if (value != _tagestarif)
                {
                    SendPropertyChanging(() => Tagestarif);
                    _tagestarif = value;
                    SendPropertyChanged(() => Tagestarif);
                }
            }
        }

        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    SendPropertyChanging(() => Id);
                    _id = value;
                    SendPropertyChanged(() => Id);
                }
            }
        }

        [DataMember]
        public string Marke
        {
            get { return _marke; }
            set {                
                if (_marke != value)
                {
                    SendPropertyChanging(() => Marke);
                    _marke = value;
                    SendPropertyChanged(() => Marke);
                } 
            }
        }

        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return _autoklasse; }
            set {                
                if (_autoklasse != value)
                {
                    SendPropertyChanging(() => AutoKlasse);
                    _autoklasse = value;
                    SendPropertyChanged(() => AutoKlasse);
                } 
            }
        }
    }
}
