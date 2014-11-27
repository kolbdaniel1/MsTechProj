using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        public IEnumerable<Auto> LoadAutos()
        {
            using( var context = new AutoReservationEntities()) {
                List<Auto> autoList = context.Autos.ToList();
                return autoList;
            }
        }
        public Auto LoadAuto(int id)
        {
            using( var context = new AutoReservationEntities()) {
                Auto auto = context.Autos.Find(id);
                return auto;
            }
        }

        public void AddAuto(Auto auto)
        {
            using( var context = new AutoReservationEntities()) {
                context.Autos.Add(auto);
                context.SaveChanges();
            }
        }

        public void UpdateAuto(Auto modified, Auto original)
        {
            using( var context = new AutoReservationEntities()) {

                try {
                    context.Autos.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                 }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException<Auto>(context, original);
                }
            }
        }

        public void DeleteAuto(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                var auto = context.Autos.First(c => c.Id == id);
                context.Autos.Remove(auto);
                context.SaveChanges();
            }
        }


        public IEnumerable<Kunde> LoadKunden()
        {
            using (var context = new AutoReservationEntities())
            {
                List<Kunde> KundeList = context.Kunden.ToList();
                return KundeList;
            }
        }
        public Kunde LoadKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                Kunde kunde = context.Kunden.Find(id);
                return kunde;
            }
        }

        public void AddKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunden.Add(kunde);
                context.SaveChanges();
            }
        }

        public void UpdateKunde(Kunde modified, Kunde original)
        {
            using (var context = new AutoReservationEntities())
            {
                try {   
                    context.Kunden.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException<Kunde>(context, original);
                }
            }
        }

        public void DeleteKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                var Kunde = context.Kunden.First(c => c.Id == id);
                context.Kunden.Remove(Kunde);
                context.SaveChanges();
            }
        }

        public IEnumerable<Reservation> LoadReservationen()
        {
            using (var context = new AutoReservationEntities())
            {
                List<Reservation> ReservationList = context.Reservationen.ToList();
                return ReservationList;
            }
        }
        public Reservation LoadReservation(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                Reservation reservation = context.Reservationen.Find(id);
                return reservation;
            }
        }

        public void AddReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservationen.Add(reservation);
                context.SaveChanges();
            }
        }

        public void UpdateReservation(Reservation modified, Reservation original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException<Reservation>(context, original);
                }
            }
        }

        public void DeleteReservation(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                var Reservation = context.Reservationen.First(c => c.ReservationNr == id);
                context.Reservationen.Remove(Reservation);
                context.SaveChanges();
            }
        }

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }

    }
}