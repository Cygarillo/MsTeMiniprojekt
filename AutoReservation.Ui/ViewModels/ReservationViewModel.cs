using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Ui.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly List<ReservationDto> reservationenOriginal = new List<ReservationDto>();
        private ObservableCollection<ReservationDto> reservationen;
        private ReservationDto selectedReservation;
        public ReservationDto SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                if (selectedReservation != value)
                {
                    SendPropertyChanging(() => SelectedReservation);
                    selectedReservation = value;
                    SendPropertyChanged(() => SelectedReservation);
                }
            }
        }


        private ObservableCollection<AutoDto> autos;
        public ObservableCollection<AutoDto> Autos
        {
            get
            {
                if (autos == null)
                {
                    autos = new ObservableCollection<AutoDto>();
                }
                return autos;
            }
        }




        public ObservableCollection<ReservationDto> Reservationen
        {
            get
            {
                if (reservationen == null)
                {
                    reservationen = new ObservableCollection<ReservationDto>();
                }
                return reservationen;
            }
        }


        private ObservableCollection<KundeDto> kunden;
        public ObservableCollection<KundeDto> Kunden
        {
            get
            {
                if (kunden == null)
                {
                    kunden = new ObservableCollection<KundeDto>();
                }
                return kunden;
            }
        }

       

        private RelayCommand loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(
                        param => Load(),
                        param => CanLoad()
                    );
                }
                return loadCommand;
            }
        }
        private bool CanLoad()
        {
            return Service != null;
        }
        

        protected override void Load()
        {

            Kunden.Clear();
            foreach (KundeDto kunde in Service.GetKunden())
            {
                Kunden.Add(kunde);
            }

            Autos.Clear();
            foreach (AutoDto auto in Service.GetAutos())
            {
                Autos.Add(auto);
            }

            Reservationen.Clear();
            reservationenOriginal.Clear();
            foreach (ReservationDto res in Service.GetReservationen())
            {
                Reservationen.Add(res);
                reservationenOriginal.Add((ReservationDto)res.Clone());
            }
            selectedReservation = Reservationen.FirstOrDefault();

            reservationen.ToList().ForEach(r =>
                                                {
                                                    r.Auto =
                                                        Autos.ToList().Find(a => a.Id == r.Auto.Id);
                                                    r.Kunde = Kunden.ToList().Find(k => k.Id == r.Kunde.Id);
                                                });
        }



        #region Save-Command

        private RelayCommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(
                        param => SaveData(),
                        param => CanSaveData()
                    );
                }
                return saveCommand;
            }
        }

        private void SaveData()
        {
            foreach (ReservationDto reservation in Reservationen)
            {
                if (reservation.ReservationNr == default(int))
                {
                    Service.AddReservation(reservation);
                }
                else
                {
                    ReservationDto original = reservationenOriginal.FirstOrDefault(ao => ao.ReservationNr == reservation.ReservationNr);
                    Service.UpdateReservation(original, reservation);
                }
            }
            Load();
        }

        private bool CanSaveData()
        {
            if (Service == null)
            {
                return false;
            }

            StringBuilder errorText = new StringBuilder();
            foreach (ReservationDto res in Reservationen)
            {
                string error = res.Validate();
                if (!string.IsNullOrEmpty(error))
                {
                    errorText.AppendLine(res.ToString());
                    errorText.AppendLine(error);
                }
            }

            ErrorText = errorText.ToString();
            return string.IsNullOrEmpty(ErrorText);
        }


        #endregion

        #region New-Command

        private RelayCommand newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(
                        param => New(),
                        param => CanNew()
                    );
                }
                return newCommand;
            }
        }

        private void New()
        {
            Reservationen.Add(new ReservationDto { Von = DateTime.Today,Bis = DateTime.Today.AddDays(20)});
        }

        private bool CanNew()
        {
            return Service != null;
        }

        #endregion

        #region Delete-Command

        private RelayCommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        param => Delete(),
                        param => CanDelete()
                    );
                }
                return deleteCommand;
            }
        }

        private void Delete()
        {
            Service.DeleteReservation(selectedReservation);
            Load();
        }

        private bool CanDelete()
        {
            return
                selectedReservation != null &&
                selectedReservation.ReservationNr != default(int) &&
                Service != null;
        }

        #endregion
    }
}
