using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Service.Wcf;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {

        private AutoReservationEntities context;

        public AutoReservationBusinessComponent(AutoReservationEntities context)
        {
            this.context = context;
        }

        IEnumerable<AutoDto> LoadAutos()
        {
            List<Auto> autoList = context.Autos.ToList();
            List<AutoDto> autoDtoList = autoList.ConvertToDtos();
            return autoDtoList;
        }
        AutoDto LoadAuto(int id) 
        {
            Auto auto = context.Autos.Find(id);
            AutoDto autoDto = auto.ConvertToDto();
            return autoDto;
        }

        void AddAuto(AutoDto auto)
        {
            context.Autos.Add(auto.ConvertToEntity());
        }

        void UpdateAuto(AutoDto modified, AutoDto original)
        {
            var originalEntity = original.ConvertToEntity();
            var modifiedEntity = modified.ConvertToEntity();

            context.Autos.Attach(originalEntity);
            context.Entry(originalEntity).CurrentValues.SetValues(modifiedEntity);
        }

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


        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }

    }
}