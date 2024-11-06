using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementaions
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationDBContext _context;
        public PatientRepository(ApplicationDBContext db)
        {
            _context = db;
        }
        public IEnumerable<Patient> GetAllPatients()
        {
            var y = _context.Patients.ToList();
            return y;
        }

        public Patient GetPatientByID(int id)
        {
            var y = _context.Patients.Where(x => x.Id == id).FirstOrDefault() ?? null;
            return y;
        }

        public int CreatePatient(Patient patient)
        {
            int result = -1;
            if (patient == null)
            {
                result = 0;
            }
            else
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                result = patient.Id;
            }
            return result;
        }

        public int UpdatePatient(Patient patient)
        {
            var f = _context.Patients.Where(x => x.Id == patient.Id).FirstOrDefault() ?? null;
            if (f != null)
            {
                f.Id = patient.Id;
                f.Name = patient.Name;
                f.Description = patient.Description;
                f.Age = patient.Age;

                _context.SaveChanges();
                return f.Id;
            }
            return -1;
        }

        public int DeletePatient(int id)
        {
            if (id == 0)
            {
                return -1;
            }
            var f = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
            if(f != null)
            {
                _context.Patients.Remove(f);
                _context.SaveChanges();
                return f.Id;
            }
            return 0;
        }

    

        //byDefault
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
