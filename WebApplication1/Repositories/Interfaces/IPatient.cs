using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IPatient : IDisposable
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientByID(int id);
        int CreatePatient(Patient patient);
        int UpdatePatient(Patient patient);
        int DeletePatient(int id);
    }
}
