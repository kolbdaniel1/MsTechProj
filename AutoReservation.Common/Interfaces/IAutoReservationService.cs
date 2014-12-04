using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
   [ServiceContract]
    public interface IAutoReservationService
    {
       [OperationContract]
        IEnumerable<AutoDto> LoadAutos();

       [OperationContract] 
       AutoDto LoadAuto(int id);

       [OperationContract]
        void AddAuto(AutoDto auto);

       [OperationContract]
        void UpdateAuto(AutoDto modified, AutoDto original);

       [OperationContract]
        void DeleteAuto(int id);

       [OperationContract]
        IEnumerable<KundeDto> LoadKunden();

       [OperationContract]
        KundeDto LoadKunde(int id);

       [OperationContract]
        void AddKunde(KundeDto Kunde);
       
       [OperationContract]
        void UpdateKunde(KundeDto modified, KundeDto original);

       [OperationContract]
        void DeleteKunde(int id);

       [OperationContract]
        IEnumerable<ReservationDto> LoadReservationen();

       [OperationContract]
        ReservationDto LoadReservation(int id);

       [OperationContract]
        void AddReservation(ReservationDto Reservation);

       [OperationContract]
        void ReservationUpdate(ReservationDto modified, ReservationDto original);

       [OperationContract]
        void DeleteReservation(int id);





    }
}
