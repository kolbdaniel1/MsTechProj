using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public IEnumerable<AutoDto> LoadAutos()
        {
            throw new NotImplementedException();
        }

        public AutoDto LoadAuto(int id)
        {
            throw new NotImplementedException();
        }

        public void AddAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KundeDto> LoadKunden()
        {
            throw new NotImplementedException();
        }

        public KundeDto LoadKunde(int id)
        {
            throw new NotImplementedException();
        }

        public void AddKunde(KundeDto Kunde)
        {
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            throw new NotImplementedException();
        }

        public void DeleteKunde(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReservationDto> LoadReservationen()
        {
            throw new NotImplementedException();
        }

        public ReservationDto LoadReservation(int id)
        {
            throw new NotImplementedException();
        }

        public void AddReservation(ReservationDto Reservation)
        {
            throw new NotImplementedException();
        }

        public void ReservationUpdate(ReservationDto modified, ReservationDto original)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}