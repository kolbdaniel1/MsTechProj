using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;
using System;

namespace AutoReservation.Ui.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly List<ReservationDto> reservationOriginal = new List<ReservationDto>();
        private ObservableCollection<ReservationDto> reservations;
        public ObservableCollection<ReservationDto> Reservations
        {
            get
            {
                if (reservations == null)
                {
                    reservations = new ObservableCollection<ReservationDto>();
                }
                return reservations;
            }
        }

        public ObservableCollection<KundeDto> Kunden { get; set; }

        public ObservableCollection<AutoDto> Autos { get; set; }

        private ReservationDto selectedReservation;
        public ReservationDto SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                if (selectedReservation != value)
                {
                    selectedReservation = value;
                    RaisePropertyChanged();
                }
            }
        }

        #region Load-Command

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

        protected override void Load()
        {
            Reservations.Clear();
            reservationOriginal.Clear();
            foreach (ReservationDto reservation in Service.LoadReservationen())
            {
                Reservations.Add(reservation);
                reservationOriginal.Add((ReservationDto)reservation.Clone());
            }
            selectedReservation = Reservations.FirstOrDefault();
     
            Kunden = new ObservableCollection<KundeDto>(Service.LoadKunden());
            Autos = new ObservableCollection<AutoDto>(Service.LoadAutos());
        }

        private bool CanLoad()
        {
            return Service != null;
        }

        #endregion

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
            foreach (ReservationDto reservation in Reservations)
            {
                if (reservation.ReservationNr == default(int))
                {
                    Service.AddReservation(reservation);
                }
                else
                {
                    ReservationDto original = reservationOriginal.FirstOrDefault(rs => rs.ReservationNr == reservation.ReservationNr);
                    Service.ReservationUpdate(reservation, original);
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
            foreach (ReservationDto reservation in Reservations)
            {
                string error = reservation.Validate();
                if (!string.IsNullOrEmpty(error))
                {
                    errorText.AppendLine(reservation.ToString());
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
            Reservations.Add(new ReservationDto { Von = DateTime.Today, 
                Bis = DateTime.Today,
            });
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
            Service.DeleteReservation(selectedReservation.ReservationNr);
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