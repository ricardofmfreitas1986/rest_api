using MedicationRESTApi.Models;

namespace MedicationRESTApi.Contracts
{
    public interface IMedicationService
    {
        IEnumerable<Medication> GetAllMedications();
        Medication Add(Medication newMedication);
        Medication GetById(Guid id);
        void Remove(Guid id);
    }
}
