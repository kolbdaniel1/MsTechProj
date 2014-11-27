﻿using AutoReservation.Common.DataTransferObjects;
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
        IEnumerable<AutoDto> LoadAutos()
        {
            using( var context = new AutoReservationEntities()) {
                List<Auto> autoList = context.Autos.ToList();
                List<AutoDto> autoDtoList = autoList.ConvertToDtos();
                return autoDtoList;
            }
        }
        AutoDto LoadAuto(int id)
        {
            using( var context = new AutoReservationEntities()) {
                Auto auto = context.Autos.Find(id);
                AutoDto autoDto = auto.ConvertToDto();
                return autoDto;
            }
        }

        void AddAuto(AutoDto auto)
        {
            using( var context = new AutoReservationEntities()) {
                context.Autos.Add(auto.ConvertToEntity());
                context.SaveChanges();
            }
        }

        void UpdateAuto(AutoDto modified, AutoDto original)
        {
            using( var context = new AutoReservationEntities()) {
                var originalEntity = original.ConvertToEntity();
                var modifiedEntity = modified.ConvertToEntity();

                context.Autos.Attach(originalEntity);
                context.Entry(originalEntity).CurrentValues.SetValues(modifiedEntity);
                context.SaveChanges();
            }
        }

        void DeleteAuto(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                var auto = context.Autos.First(c => c.Id == id);
                context.Autos.Remove(auto);
                context.SaveChanges();
            }
        }


        IEnumerable<KundeDto> LoadKunden()
        {
            using (var context = new AutoReservationEntities())
            {
                List<Kunde> KundeList = context.Kunden.ToList();
                List<KundeDto> KundeDtoList = KundeList.ConvertToDtos();
                return KundeDtoList;
            }
        }
        KundeDto LoadKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                Kunde Kunde = context.Kunden.Find(id);
                KundeDto kundeDto = Kunde.ConvertToDto();
                return kundeDto;
            }
        }

        void AddKunde(KundeDto Kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunden.Add(Kunde.ConvertToEntity());
                context.SaveChanges();
            }
        }

        void UpdateKunde(KundeDto modified, KundeDto original)
        {
            using (var context = new AutoReservationEntities())
            {
                var originalEntity = original.ConvertToEntity();
                var modifiedEntity = modified.ConvertToEntity();

                context.Kunden.Attach(originalEntity);
                context.Entry(originalEntity).CurrentValues.SetValues(modifiedEntity);
                context.SaveChanges();
            }
        }

        void DeleteKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                var Kunde = context.Kunden.First(c => c.Id == id);
                context.Kunden.Remove(Kunde);
                context.SaveChanges();
            }
        }

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