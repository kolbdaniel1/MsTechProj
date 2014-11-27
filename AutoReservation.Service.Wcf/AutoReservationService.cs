using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        AutoReservationBusinessComponent businessComponent;

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public IEnumerable<AutoDto> LoadAutos()
        {
            WriteActualMethod();
            IEnumerable<Auto> autoList = businessComponent.LoadAutos();
            return autoList.ConvertToDtos();
        }

        public AutoDto LoadAuto(int id)
        { 
           WriteActualMethod();
           return businessComponent.LoadAuto(id).ConvertToDto();
        }

        public void AddAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.AddAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            businessComponent.UpdateAuto(modified.ConvertToEntity(), original.ConvertToEntity());
        }

        public void DeleteAuto(int id)
        {
            WriteActualMethod();
            businessComponent.DeleteAuto(id);
        }

        public IEnumerable<KundeDto> LoadKunden()
        {
            WriteActualMethod();
            IEnumerable<Kunde> kundenList = businessComponent.LoadKunden();
            return kundenList.ConvertToDtos();
        }

        public KundeDto LoadKunde(int id)
        {
            WriteActualMethod();
            return businessComponent.LoadKunde(id).ConvertToDto();
        }

        public void AddKunde(KundeDto Kunde)
        {
            WriteActualMethod();
            businessComponent.AddKunde(Kunde.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            businessComponent.UpdateKunde(modified.ConvertToEntity(), original.ConvertToEntity());
        }

        public void DeleteKunde(int id)
        {
            WriteActualMethod();
            businessComponent.DeleteKunde(id);
        }

        public IEnumerable<ReservationDto> LoadReservationen()
        {
            WriteActualMethod();
            IEnumerable<Reservation> reservationList = businessComponent.LoadReservationen();
            return reservationList.ConvertToDtos();
        }

        public ReservationDto LoadReservation(int id)
        {
            WriteActualMethod();
            return businessComponent.LoadReservation(id).ConvertToDto();
        }

        public void AddReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.AddReservation(reservation.ConvertToEntity());

        }

        public void ReservationUpdate(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            businessComponent.UpdateReservation(modified.ConvertToEntity(), original.ConvertToEntity());
        }

        public void DeleteReservation(int id)
        {
            WriteActualMethod();
            businessComponent.DeleteReservation(id);
        }
    }
}