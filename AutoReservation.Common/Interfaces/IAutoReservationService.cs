using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        IEnumerable<AutoDto> LoadAutos();
        AutoDto LoadAuto(int id);
        
        void AddAuto(AutoDto auto);

        void UpdateAuto(AutoDto modified, AutoDto original);

        void DeleteAuto(int id);

        IEnumerable<KundeDto> LoadKunden();
        KundeDto LoadKunde(int id);

        void AddKunde(KundeDto Kunde);

        void UpdateKunde(KundeDto modified, KundeDto original);

        void DeleteKunde(int id);

        IEnumerable<ReservationDto> LoadReservationen();
        ReservationDto LoadReservation(int id);

        void AddReservation(ReservationDto Reservation);

        void ReservationUpdate(ReservationDto modified, ReservationDto original);

        void DeleteReservation(int id);





    }
}
